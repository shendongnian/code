    var connection = new OleDbConnection(connectionString);
    connection.Open();
    var dt = new DataTable("Attachments");
    var dataAdapter = new OleDbDataAdapter(@"select attachmentColumn.FileData as filedata, attachmentColumn.FileName as filename, attachmentColumn.FileType as filetype from tablename", connection);
    dataAdapter.Fill(dt);
    
    foreach (DataRow row in dt.Rows)
    {
      var filename = row["filename"].ToString();
      if (string.IsNullOrWhiteSpace(filename)) continue;
      var filedata = (byte[]) row["filedata"];
      int header = (int) filedata[0];
      byte[] actualFile = new byte[filedata.Length - header];
      Buffer.BlockCopy(filedata, header, actualFile, 0, actualFile.Length);
      // do stuff with byte array!
      File.WriteAllBytes("C:\\" + filename, actualFile);
    }
