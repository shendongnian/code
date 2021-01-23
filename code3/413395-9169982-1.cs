        void LoadFavorites()
        {
            if (number <= maxnumber)
            {
                if (Properties.Settings.Default.FavoriteList.Contains("'"+number+"'"))
                {
                    this.listBox1.Items.Add(number++); // add number to list THEN increment number by one 
                }
                LoadFavorites(); 
            }
              
        }
