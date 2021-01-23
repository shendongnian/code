    connection.Open()
    var insertUser = new SqlCommand(insCmd, myConnection);   
    
    foreach(var item in CheckBoxList1.Items)
    {
      insertUser.Parameters.Clear();
      // your code where you can use Item.Text to add parameters
      // i have no idea about your textboxes though 
      insertUser.ExecuteNonQuery();
    }
    connection.Close();
