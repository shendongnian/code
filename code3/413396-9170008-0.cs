     if (number <= maxnumber)
                {
                    if (Properties.Settings.Default.FavoriteList.Contains("'"+number+"'"))
                    {
                        this.listBox1.Items.Add(number);
                    }
                    number = number + 1;
                    LoadFavorites();
                }
   
               
