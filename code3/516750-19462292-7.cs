        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboBoxItem = new ComboBoxItem(); // Create example instance of our desired type.
            Type type1 = cboBoxItem.GetType();
            object cboBoxItemInstance = Activator.CreateInstance(type1); // Construct an instance of that type.
            for (int i = 0; i < 12; i++)
            {
                string newName = "stringExample" + i.ToString();
               // Generate the objects from our list of strings.
                ComboBoxItem item = this.CreateComboBoxItem((ComboBoxItem)cboBoxItemInstance, "nameExample_" + newName, newName);
                cboBox1.Items.Add(item); // Add each newly constructed item to our NAMED combobox.
            }
        }
        private ComboBoxItem CreateComboBoxItem(ComboBoxItem myCbo, string content, string name)
        {
            Type type1 = myCbo.GetType();
            ComboBoxItem instance = (ComboBoxItem)Activator.CreateInstance(type1);
            // Here, we're using reflection to get and set the properties of the type.
            PropertyInfo Content = instance.GetType().GetProperty("Content", BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo Name = instance.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
            this.SetProperty<ComboBoxItem, String>(Content, instance, content);
            this.SetProperty<ComboBoxItem, String>(Name, instance, name);
            return instance;
            //PropertyInfo prop = type.GetProperties(rb1);
        }
