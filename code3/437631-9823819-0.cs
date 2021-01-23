        private static void CheckRadioButton(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is RadioButton)
                {
                    if (radio.Checked == true)
                    {
                        //code continue to next 
                    }
                    else
                    {
                        MessageBox.Show("You must select at least one.");
                    }
                }
                else if (c.Controls.Count > 0)
                    CheckRadioButton(c);
            }
        }
