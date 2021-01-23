        public static void InvokeOnClassPropertyChange(this object instance,string PropertyName,Action action)
        {
            Type type = instance.GetType();
            var fulllist = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(w => w.DeclaringType == type).ToList();
            if (fulllist.Select(p => p.Name).Contains(PropertyName))
            {
                action.Invoke();
            }
        }
