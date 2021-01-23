    private void Listview1_ItemChecked(object sender, ItemCheckedEventArgs e) 
    {
        ListViewItem item = e.Item as ListViewItem;
        if (item != null)
        {
           if (item.Checked) 
           {
               N++;
           }  
           else
           {
               N--;
           }
        }
        Textbox1.Text = N.ToString();
    }
