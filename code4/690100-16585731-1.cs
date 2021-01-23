    if (placeRows.Controls.Count > 0)
                {
                    foreach (Control ctrl in placeRows.Controls)
                    {
                        TextBox txt = (TextBox)ctrl.FindControl("txtValue");
                        TextBox txtB = (TextBox)ctrl.FindControl("txtValueB");
                        string message = txt.Text + txtB.Text;
                    }
                }
