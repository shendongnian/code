    private void button1_Click(object sender, EventArgs e)
    {
        using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection("Data Source=localhost; Initial Datalog=myDatabase; Integrated Security=TRUE;")) 
      {
          using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("insert into trans values("+label9.Text+","+DateTime.Now.ToString()+");", connection)) 
        {
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
         }
      }
    }
