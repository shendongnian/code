    foreach(ListViewItem theItem in ListView1)
    {
        if(theItem.Text == "Column Name")
        {
            theItem.ForeColor = Color.Red;
            // You also have access to the list view's SubItems collection
            theItem.SubItems[0].ForeColor = Color.Blue;
        }
    }
