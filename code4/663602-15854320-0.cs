    try
    {
          SqlCommand command = new SqlCommand(sqlquery, cn);
          command.Parameters.AddWithValue("Username", username);
          command.Parameters.AddWithValue("Password", password);
          command.ExecuteNonQuery();
          command.Parameters.Clear();
          MessageBox.Show("User Added");
    }
    catch (Exception ex)
    {
          MessageBox.Show(ex.Message);
    }
