        void LoadFavorites()
        {
            if (number <= maxnumber)
            {
                if (Properties.Settings.Default.FavoriteList.Contains("'"+number+"'"))
                {
                    this.listBox1.Items.Add(number);
                }
            }
            // Increases number by 1 and reruns
            number = number + 1;
            if(number <= maxnumber) // create a condition to call this
              LoadFavorites(); // problem is probably here
        }
