    if (txtFonecom.TextLength == 13)
                    {
                        txtFonecom.Text = txtFonecom.Text.Replace("-", txtFonecom.Text.Substring(txtFonecom.Text.IndexOf('-') + 1, 1));                    
                        txtFonecom.Text = txtFonecom.Text.Remove(8, 1);
                        txtFonecom.Text = txtFonecom.Text.Insert(8, "-");
                        txtFonecom.SelectionStart = txtFonecom.Text.Length;
                    }
