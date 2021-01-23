        private void AddCheckBoxes()
        {
            var converter = new FlagsEnumValueConverter();
            foreach (Department dept in Enum.GetValues(typeof(Department)))
            {
                if (dept != Department.None)
                {
                    var binding = new Binding()
                    {
                        Path = new PropertyPath("Department"),
                        Converter = converter,
                        ConverterParameter = dept
                    };
                    var checkBox = new CheckBox() { Content = dept.ToString() };
                    checkBox.SetBinding(CheckBox.IsCheckedProperty, binding);
                    DepartmentsPanel.Children.Add(checkBox);
                }
            }
        }
