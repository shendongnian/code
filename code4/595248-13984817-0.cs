    var sessionColor = Session["Color"].ToString();
                    if (sessionColor == "red")
                    {
                        var buttons = ButtonPanel.Controls.OfType<Button>();
                        foreach (var button in buttons)
                        {
                            if (button.BackColor == Color.Red)
                            {
                                button.Visible = true;
                            }
                            else
                            {
                                button.Visible = false;
                            }
                        }
    
                    }
                    else if (sessionColor == "green")
                    {
                        var buttons = ButtonPanel.Controls.OfType<Button>();
                        foreach (var button in buttons)
                        {
                            if (button.BackColor == Color.Green)
                            {
                                button.Visible = true;
                            }
                            else
                            {
                                button.Visible = false;
                            }
                        }
                    }
                    else if (sessionColor == "blue")
                    {
                        var buttons = ButtonPanel.Controls.OfType<Button>();
                        foreach (var button in buttons)
                        {
                            if (button.BackColor == Color.Blue)
                            {
                                button.Visible = true;
                            }
                            else
                            {
                                button.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        var buttons = ButtonPanel.Controls.OfType<Button>();
                        foreach (var button in buttons)
                        {
                            button.Visible = false;
    
                        }
                    }
