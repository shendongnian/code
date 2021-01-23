    foreach (Type type in myAssembly.GetTypes())
    {
        foreach (PropertyInfo property in type.GetProperties())
        {
            MessageBox.Show(property.Name + " - " + property.PropertyType);
        }
    }
