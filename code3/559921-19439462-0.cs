        private RadioButton CreateRadioButton(RadioButton rb1, string content, Thickness margin, string name)
        {
            //private RadioButton CreateRadioButton(RadioButton rb1, string content, Thickness margin, string name)
            // We create the objects and then get their properties. We can easily fill a list.
            //MessageBox.Show(rb1.ToString());
            Type type1 = rb1.GetType();
            RadioButton instance = (RadioButton)Activator.CreateInstance(type1);
            //MessageBox.Show(instance.ToString()); // Should be the radiobutton type.
            PropertyInfo Content = instance.GetType().GetProperty("Content", BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo Margin = instance.GetType().GetProperty("Margin", BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo Name = instance.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
            // This is how we set properties in WPF via late-binding.
            this.SetProperty<RadioButton, String>(Content, instance, content);
            this.SetProperty<RadioButton, Thickness>(Margin, instance, margin);
            this.SetProperty<RadioButton, String>(Name, instance, name);
            
            return instance;
            //PropertyInfo prop = type.GetProperties(rb1);
        }
        // Note: You are going to want to create a List<RadioButton>
