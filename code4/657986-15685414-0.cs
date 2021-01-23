    string selectSql = "SELECT * FROM SomeTable WHERE ID = @ID";
    int id;
    if (!int.TryParse(txtID.Text, out id))
        MessageBox.Show("ID must be an integer.");
    else
    {
        using (var myCon = new SqlConnection(connectionString))
        using (var selectCommand = new SqlCommand(selectSql, myCon))
        {
            selectCommand.Parameters.AddWithValue("@ID", id);
            myCon.Open();
            using (var reader = selectCommand.ExecuteReader())
            {
                // do something with the records
            }
        }
    }
