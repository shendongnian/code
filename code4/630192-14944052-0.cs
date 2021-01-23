        public static void ClearAll(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var texbox = c as TextBox;
                var comboBox = c as ComboBox;
                var dateTimePicker = c as DateTimePicker;
                if (texbox != null)
                    texbox.Clear();
                if (comboBox != null)
                    comboBox.SelectedIndex = -1;
                if (dateTimePicker != null)
                {
                    dateTimePicker.Format = DateTimePickerFormat.Short;
                    dateTimePicker.CustomFormat = " ";
                }
                if (c.HasChildren)
                    ClearAll(c);
            }
        }
