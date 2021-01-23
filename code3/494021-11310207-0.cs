    private void listBox1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0)
        {
            var c_id = (e.AddedItems[0] as Foodlist).C_ID;
        }
    }
