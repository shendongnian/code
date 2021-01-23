    for (int i = 1; i < count; i++)
                {
                    CheckBox chbx = (CheckBox) this.FindControl("checkBox" + i);
                    TextBox txtb = (TextBox)this.FindControl("textBox" + i);
                    Label lbl = (Label) this.FindControl("label" + i);
                    if (chbx.Checked && !string.IsNullOrEmpty(txtb.Text))
                    {
                        if (RemoteFileExists(txtb.Text) == true)
                        {
                            lbl.Text = "UP";
                        }
                        else
                        {
                            lbl.Text = "DOWN";
                        }
                    }
                }
