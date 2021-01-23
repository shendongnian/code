    //reading the file content
    FileStream s = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    byte[] buffer = new byte[s.Length];
    s.Read(buffer, 0, s.Length);
    s.Close();
    
    //adding a row in the database
    SqlCommand insertCommand = new SqlCommand("insertCommand into myTable (binaryField) values (@filedata)", youconnection);
    insertCommand.Parameters.Add(new SqlParameter ("@filedata", buffer ));
    insertCommand.ExecuteNonQuery();
