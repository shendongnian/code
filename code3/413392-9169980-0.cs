        int number = 1; 
        int maxnumber = 10000; 
        void LoadFavorites()
        {
            if (number <= maxnumber)
            {
                if (Properties.Settings.Default.FavoriteList.Contains("'"+number+"'"))
                {
                    this.listBox1.Items.Add(number);
                }
                // Increases number by 1 and reruns
                number = number + 1;
                LoadFavorites(); // problem is probably here
            }
        }
