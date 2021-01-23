                int i = 0;
                foreach (var item in catagoryDropDown.Items)
                {
                    if (item.ToString().Equals("Sick Leave"))
                    {
                        catagoryDropDown.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
