    viewList.View = View.Details;
    
    viewList.Columns.Add("Key");
    viewList.Columns.Add("Value");
        
    ListViewItem lvi1 = new ListViewItem();
        
    lvi1.Text = "Key";
    lvi1.SubItems.Add("Value");
    viewList.Items.Add(lvi1);
