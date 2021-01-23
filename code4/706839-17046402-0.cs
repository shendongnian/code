            var dataString = new string[]
                                        {
                                            "All",
                                            "Housing",
                                            "Transportation",
                                            "Food",
                                            "Personal Insurance",
                                            "Health",
                                            "Entertainment",
                                            "Personal care",
                                            "Cash",
                                            "Misc",
                                        };
            _Menu1.ItemsSource = dataString;
            var index = dataString.ToList().IndexOf("Housing");
            _Menu1.SelectedIndex == index;
