     public static void ClearControl(Control control)
            {
                if (control is TextBox)
                {
                    TextBox txtbox = (TextBox)control;
                    txtbox.Text = string.Empty;
                }
                else if (control is CheckBox)
                {
                    CheckBox chkbox = (CheckBox)control;
                    chkbox.Checked = false;
                }
                else if (control is RadioButton)
                {
                    RadioButton rdbtn = (RadioButton)control;
                    rdbtn.Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)control;
                    dtp.Value = DateTime.Now;
                }
                else if (control is ComboBox)
                {
                    ComboBox cmb = (ComboBox)control;
                    if (cmb.DataSource != null)
                    {
                        cmb.SelectedItem = string.Empty;
                        cmb.SelectedValue = 0;
                    }
                }
                ClearErrors(control);
                // repeat for combobox, listbox, checkbox and any other controls you want to clear
                if (control.HasChildren)
                {
                    foreach (Control child in control.Controls)
                    {
                        ClearControl(child);
                    }
                }
    
               
            }
