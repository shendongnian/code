            foreach (Control C in GB.Controls)
            { 
                if(C is TextBox)
                {
                    (C as TextBox).Clear();
                }
                if(C is DateTimePicker)
                {
                    (C as DateTimePicker).Value = DateTime.Now;
                }
                if (C is ComboBox)
                {
                    (C as ComboBox).SelectedIndex = 0;
                }
            }
