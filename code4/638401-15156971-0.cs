    public bool checkStock()
    {
        foreach (var listBoxItem in listBox1.Items)
        {
            if (Convert.ToInt32(GetStock(listBoxItem.ToString())) == 0)
            {
                MessageBox.Show(listBoxItem.ToString() + " not in Stock!. Please delete the item before proceeding");
                return false;
            }
         }
    
        return true;
     }
