        public static void ClearControlsInPanel(ControlCollection controls, string[] ignorelist)
        {
            foreach (Control c1 in controls)
            {
                if (c1 is TextBox)
                {
                    if (!ignorelist.Contains(c1.ID.ToString()))
                    {
                        ((TextBox)c1).Text = "";
                    }
                }
                else if (c1 is DropDownList)
                {
                    if (!ignorelist.Contains(c1.ID.ToString()))
                    {
                        ((DropDownList)c1).SelectedIndex = 0;
                    }
                }
                else
                {
                    if (c1.HasControls())
                    {
                        ClearControlsInPanel(c1.Controls, ignorelist);
                    }
                }
            }
        }
