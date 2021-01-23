    public void checkStock()
     {
        foreach (var listBoxItem in listBox1.Items)
        {
            if (Convert.ToInt32(GetStock(listBoxItem.ToString())) == 0)
            {
                MessageBox.Show(string.Format("{0} is not in stock!",listBoxItem.ToString()));
            }
        }
     }        
  
