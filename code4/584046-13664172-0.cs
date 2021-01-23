    foreach (ListViewItem iiii in listView1.Items)
    {
         int value;
         if (!Int32.TryParse(iiii.SubItems[4].ToString(), out value))
             continue; // not number was in listview (consider to show error message)
    
         if (value <= tenthousand)
         {
              labelVideoViews2.Text = "GREAT";
              labelVideoViews2.ForeColor = Color.Green;
              break;
         }
    }
