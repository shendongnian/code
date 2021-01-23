                    if (TxtPath.Text != string.Empty)
                     {
                      StreamReader srr = new StreamReader(TxtPath.Text);
                        try
                        {
                            ss = srr.ReadToEnd().Split('\n');
                            MessageBox.Show("File Successfully Loded in Memory \n" + TxtPath.Text, "System Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            throw new Exception("File are not readable or write protacted");
                        }
                        LblLineCount.Text = ss.Count().ToString();
                    }
                    else
                    {
                        MessageBox.Show("Please Browse any Log File 1st", "System Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
