    string selectSql = "SELECT * FROM SomeTable WHERE ID = @ID";
    string insertSql = "INSERT INTO SomeTable (ID, AgeGroup, Gender) VALUES (@ID, @AgeGroup, @Gender)";
    int id;
    if (!int.TryParse(txtID.Text, out id))
        MessageBox.Show("ID must be an integer.");
    else
    {
        using (var myCon = new OleDbConnection(connectionString))
        {
            bool idExistsAlready = true;
            using (var selectCommand = new OleDbCommand(selectSql, myCon))
            {
                selectCommand.Parameters.AddWithValue("@ID", id);
                myCon.Open();
                using (var reader = selectCommand.ExecuteReader())
                    idExistsAlready = reader.HasRows;
            }
            if (idExistsAlready)
                MessageBox.Show("ID exists already.");
            else
            {
                using (var insertCommand = new OleDbCommand(insertSql, myCon))
                {
                    insertCommand.Parameters.AddWithValue("@ID", id);
                    insertCommand.Parameters.AddWithValue("@AgeGroup", cBAgeGroup.Text);
                    insertCommand.Parameters.AddWithValue("@Gender", cBGender.Text);
                    int affectedRecords = insertCommand.ExecuteNonQuery();
                }
            }
        }
    }
