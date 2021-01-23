           `SqlConnection myConnection = new SqlConnection(@"Server=YOURSERVER;Database=YOURDATABASE;User id=YOURID; Password=YOURPASSWORD");
            myConnection.Open();
            SqlCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "THE_NAME_OF_YOUR_STOREDPROCEDURE";
            myCommand.Parameters.AddWithValue("@YOURPARAMETER", THE_VALUE_OF_THE_PARAMETER);
            SqlDataReader myReader = myCommand.ExecuteReader();
            
            while(myReader.Read())
            {
              myComboBox.Items.Add(myReader["YOUR_COLUMN_NAME"]);
            }
            myReader.Close();
            myConnection.Close();`
