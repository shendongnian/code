     foreach (Control item in tabControl1.SelectedTab.Controls)
                {
                    if (item.GetType().Equals(typeof(TextBox)))
                    {
                        item.Text = string.Empty;
                    }
                }
