    /// <summary>
    /// Generic method that uses reflection for wiring up a local class to the corresponding win32_class and properties.
    /// </summary>
    /// <typeparam name="T">A class who's name and fields correspond to those of a WMI class.</typeparam>
    /// <returns>A collection of WMI data.</returns>
    public static IEnumerable<T> WmiSnapshot<T>()
    {
        // The name of T must match that of the WMI class
        var searcher = new ManagementObjectSearcher(new SelectQuery(Activator.CreateInstance<T>().GetType().Name));
        foreach (ManagementObject managementObject in searcher.Get())
        {
            // Creates an instance of T
            var listItem = Activator.CreateInstance<T>();
            // an array of PUBLIC FIELDS of T
            var fields = listItem.GetType().GetFields();
            // matches a value from the WMI query to a field name
            foreach (FieldInfo field in fields)
            {
                if (managementObject[field.Name] != null)
                {
                    field.SetValue(listItem,
                        field.FieldType == typeof(DateTime)
                            ? ManagementDateTimeConverter.ToDateTime(managementObject[field.Name].ToString())
                            : Convert.ChangeType(managementObject[field.Name], field.FieldType));
                }
            }
            yield return listItem;
        }
    }
