    public class Utilities
    {
        public static void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                RecursiveResetForm(control);
            }
        }
        
        private void RecursiveResetForm(Control control)
        {            
            switch (control.GetType().Name)
            {
                case "TextBox":
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                    break;
                case "ComboBox":
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                    break;
                case "CheckBox":
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                    break;
                case "ListBox":
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                    break;
                case "NumericUpDown":
                    NumericUpDown numericUpDown = (NumericUpDown)control;
                    numericUpDown.Value = 0;
                    break;
                case "GroupBox":
                    GroupBox grpBox = (GroupBox)control;
                    if (grpBox.HasChildren)
                    {
                        foreach (Control subControl in grpBox.Controls)
                        {
                            RecursiveResetForm(subControl);
                        }
                    }
                    break;
            }
        }        
    }
