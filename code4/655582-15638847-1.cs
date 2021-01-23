    internal static class ModelBuilder
    {
        internal static object Build (Dictionary<string, string> Model, Type ModelType)
        {
            var Instance = Activator.CreateInstance(ModelType);
            foreach (var Property in ModelType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                var PropertyType = Property.PropertyType;
                if (Model.ContainsKey(Property.Name))
                {
                    Property.SetValue(Instance, Convert.ChangeType(Model[Property.Name], PropertyType), null);
                }
            }
            return Instance;
        }
    }
