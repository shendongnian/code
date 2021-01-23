              if (this.ActiveControl.Tag == 1)
                {
                    if (MessageBox.Show("Do you want to save before exit?", "Closing",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        MessageBox.Show("To Do saved.", "Status",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    }
                }
