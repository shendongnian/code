    public static class EntityObjectExtensions
    {
        private static int Id;
        public static T ToEntity<T>(this int id) where T : class
        {
            lock(typeof(ModelContainer))
            {
                Id = id;
                var container = ModelContainer.Instance;
                var thisType = typeof (T);
                while (thisType.BaseType != typeof (EntityObject))
                {
                    thisType = thisType.BaseType;
                }
                var setProperty = typeof (ModelContainer).GetProperty(thisType.Name + "Set");
                dynamic set = setProperty.GetValue(container);
                var firstOrDefaultMethod =
                    typeof (Enumerable).GetMethods().FirstOrDefault(m => m.Name == "FirstOrDefault" && m.GetParameters().Count() == 2);
                var firstOrDefaultGenericMethod = firstOrDefaultMethod.MakeGenericMethod(thisType);
                var lambda = typeof (Func<,>);
                var genericLambda = lambda.MakeGenericType(thisType, typeof (bool));
                var lambdaParameter = (Func<T, bool>) Delegate.CreateDelegate(genericLambda, typeof(EntityObjectExtensions).GetMethod("Compare", BindingFlags.Static | BindingFlags.NonPublic));
                dynamic item = firstOrDefaultGenericMethod.Invoke(null, new object[] {set, lambdaParameter});
                return (T) item;
            }
        }
        private static bool Compare(dynamic item)
        {
            lock (typeof(ModelContainer))
            {
                return item.Id == Id;
            }
        }
    }
