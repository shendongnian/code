    [Serializable]
    [AttributeUsage(AttributeTargets.Property)]
    public class AutofacResolveAttribute : Attribute
    {
    }
    public class AutofactResolver
    {
        /// <summary>
        /// Injecting objects into properties marked with "AutofacResolve"
        /// </summary>
        /// <param name="obj">Source object</param>
        public static void InjectProperties(object obj)
        {
            var propertiesToInject = obj.GetType().GetProperties()
                 .Where(x => x.CustomAttributes.Any(y => y.AttributeType.Name == nameof(AutofacResolveAttribute))).ToList();
            foreach (var property in propertiesToInject)
            {
                var objectToInject = Autofact.SharedContainer.Resolve(property.PropertyType);
                property.SetValue(obj, objectToInject, null);
            }
        }
    }
