    foreach (System.Reflection.PropertyInfo prop in typeof(SystemColors).GetProperties())
    {
         if (prop.PropertyType.FullName == "System.Drawing.Color")
             ColorComboBox.Items.Add(prop.Name);
    }
