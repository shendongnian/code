    public static T? ParseOrNull<T>(this string value)
                where T : struct
            {
                T result = default(T);
    
                object[] parameters = new object[] { value, result };
                foreach (System.Reflection.MethodInfo method in
                    typeof(T).GetMethods()
                    .Where(method => method.Name == "TryParse")
                    .Where(method => method.GetParameters().Length == 2) //as opposed to the 4 argument version
                    .Take(1) //shouldn't be needed, but just in case
                    )
                {
                    method.Invoke(null, parameters);
                }
    
                return (T)parameters[1];
            }
