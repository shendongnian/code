        void MyGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            // check if the current column is the target
            if (e.PropertyName == "MyDateproperty")
            {
                // assuming it's a Text-type column
                var column = (e.Column as DataGridTextColumn);
                if (column != null)
                {
                    var binding = column.Binding as Binding;
                    if (binding != null)
                    {
                        // add a converter to the binding
                        binding.Converter = new StringFormatConverter();
                    }
                }
            }
        }
