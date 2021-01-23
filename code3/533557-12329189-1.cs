    foreach (System.Reflection.PropertyInfo prop in typeof(SystemColor).GetProperties())
    {
         if (prop.PropertyType.FullName == "System.Drawing.SystemColor")
             ColorComboBox.Items.Add(prop.Name);
    }
