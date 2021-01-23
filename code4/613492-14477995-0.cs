    public void HandleItemAdded(object sender, WindowsFormsApplication1.Form3.ItemAddedEventArgs e)
            {
    
                ListViewItem item1 = new ListViewItem(e.PartPrefix);
                item1.SubItems.Add(e.PartStartNumber);
                item1.SubItems.Add(e.<Member_Name>);
    .
    .
    .
    
                listView1.Add(item1);
    
            }  
