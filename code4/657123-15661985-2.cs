    string selectSql = "select * from SomeTable where ID = @ID";
    string insertSql = "INSERT INTO SomeTable (ID, AgeGroup, Gender) VALUES (@ID, @AgeGroup, @Gender)";
    using (var myCon = new OleDbConnection(connectionString))
    {
        int? id = (int?)null;
        using (var selectCommand = new OleDbCommand(selectSql, myCon))
        {
            selectCommand.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            myCon.Open();
            using (var reader = selectCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    id = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
        }
        if (id.HasValue)
        {
            txtID.Text = id.Value.ToString(); // btw, this is still redundant since it's the same ID
            MessageBox.Show("ID Already exist");
        }
        else
        {
            using (var insertCommand = new OleDbCommand(insertSql, myCon))
            {
                insertCommand.Parameters.AddWithValue("@ID", txtID.Text);
                insertCommand.Parameters.AddWithValue("@AgeGroup", cBAgeGroup.Text);
                insertCommand.Parameters.AddWithValue("@Gender", cBGender.Text);
                int affectedRecords = insertCommand.ExecuteNonQuery();
            }
        }
    }
