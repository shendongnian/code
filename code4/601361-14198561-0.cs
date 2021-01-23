        public static bool IsObjectEmpty(Control ctrlThis)
        {
            if (ctrlThis is TextBox)
            {
                TextBox txtThis = (TextBox)ctrlThis;
                if (txtThis.Text == "" || txtThis.Text == null)
                    return false;
            }
            else if (ctrlThis is ComboBox)
            {
                ComboBox cboThis = (ComboBox)ctrlThis;
                if (int.Parse(cboThis.SelectedValue.ToString()) == -1)
                    return false;
            }
            else if (ctrlThis is NumericUpDown)
            {
                NumericUpDown numThis = (NumericUpDown)ctrlThis;
                if (numThis.Value == 0)
                    return false;
            }
            else
            {
                //Serves as 'default' in the switch
            }
            return true;
        }
