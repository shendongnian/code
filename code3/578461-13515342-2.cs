    connection.Open()
    var insertUser = new SqlCommand(insCmd, connection);   
    
    foreach(var item in CheckBoxList1.Items)
    {
      if(!item.Selected) continue;
      insertUser.Parameters.Clear();
      // your code where you can use Item.Text to add parameters
      // i have no idea about your textboxes though 
      insertUser.ExecuteNonQuery();
    }
    connection.Close();
