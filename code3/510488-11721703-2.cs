     protected void listview1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
         ListViewItem  item= listview1.Items [e.ItemIndex];
          string productId=(item.Findcontrol("ProductID") as textbox).Text; 
         //then use this column value in your sqlcommand
       using( SqlCommand cmd = new SqlCommand
            ("delete from Products where ProductID=@ProductId", connection  ))
        {
        command.Parameters.Add(new SqlParameter("ProductId", productId));
         //Then execute the query
        }
        }
