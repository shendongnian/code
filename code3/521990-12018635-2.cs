    List<PropertyInfo> properties = new List<PropertyInfo>();
    foreach (PropertyInfo pi in typeof(Person).GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
        if ((pi.DeclaringType == typeof(PersonBase)) || (pi.DeclaringType == typeof(Person))) {
            properties.Add(pi);
        }
    }
