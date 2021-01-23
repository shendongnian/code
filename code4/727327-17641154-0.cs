    /*declare variable with scope global */
     int id;
   
    if (Listview.SelectedItems.Count > 0)
            {
                ListViewItem item;
                item = ListProducts.SelectedItems[0];
                 id = int.parse(item.SubItems[0].Text.ToString());
                }
     SqlCommand cmd = "SELECT Address, Age FROM table2 WHERE id= @item";
     cmd.Connection = YourDataBaseConnection;
     cmd.Parameters.Clear();
     cmd.Parameters.Add("@item", SqlDbType.Int).Value= id;
     con.Open();
     sqlDataReader rdr = new SqlDataReader();
     rdr= cmd.ExecuteReader();
     while(rdr.Read())
     {
       yourTextBox.Text = rdr[0].Text.Tostring();
       //place the data to desired textBox
     }
     con.Dispose();
     cmd.Dispose();
     
`
