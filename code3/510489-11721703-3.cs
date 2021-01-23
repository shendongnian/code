     protected void listview1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
         //This retrieves the selected row 
         ListViewItem  item= listview1.Items [e.ItemIndex];
         //  Fetch the control for ProductId using findControl
          int productId=int.Parse((item.Findcontrol("ProductID") as TextBox).Text);
 
         //then use this column value in your sqlcommand
       using( SqlCommand cmd = new SqlCommand
            ("delete from Products where ProductID=@ProductId", connection  ))
        {
        command.Parameters.Add(new SqlParameter("ProductId", productId));
         //Then execute the query
        }
        }
