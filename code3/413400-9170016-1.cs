    void LoadFavorites()
    {
        int number = 1; 
        int maxnumber = 10000; 
        while (number <= maxnumber)
        {
           if (Properties.Settings.Default.FavoriteList.Contains("'"+number+"'"))
           {
               this.listBox1.Items.Add(number);
           }
           number = number + 1;
        }
    }
