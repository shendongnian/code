    MySqlConnection sqlCon = new MySqlConnection("Server=***;Port=***;Database=***;Uid=***;Pwd=***;");
    MySqlCommand command = new MySqlCommand ("SELECT count(Dues) From Students");
    try
    {
      sqlCon.Open();
      command.Connection = sqlCon;
      TextBox1.Text = command.ExecuteScalar().ToString();
    }
    finally
    {
      sqlCon.Close();
    }
