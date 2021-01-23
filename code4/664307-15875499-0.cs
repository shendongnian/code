     TextBox bt = new TextBox();
                bt.Name = "population_textbox";
                bt.Text = "some";
                bt.Height = 20;
                main_layout.Children.Add(bt);
                foreach (TextBox txt in main_layout.Children)
                {
                    if (txt is TextBox)
                    {
                        if ((txt as TextBox).Name == "population_textbox")
                        {
                            MessageBox.Show((txt as TextBox).Text);
                        }
                    }
                }
