        for(int i=number; i<maxNumber; i++)
        {
            if (Properties.Settings.Default.FavoriteList.Contains("'"+i+"'"))
                {
                    this.listBox1.Items.Add(i);
                }
        }
