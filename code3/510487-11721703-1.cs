     protected void listview1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
         ListViewItem  item= listview1.Items [e.ItemIndex];
          string productId=(item.Findcontrol("ProductID") as textbox).Text; 
         //then use this column value in your sqlcommand
        SqlCommand cmd = new SqlCommand("delete from Products where ProductID='" + productId + "'", connection  
        }
