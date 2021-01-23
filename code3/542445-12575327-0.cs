    var bl = new MySqlBulkLoader(sqlconnect);
          bl.TableName = "by_switch";
          bl.FieldTerminator = ",";
         bl.LineTerminator = "\n";
          bl.FileName = files.FirstOrDefault().ToString();
           bl.NumberOfLinesToSkip = 1;
        int inserted = bl.Load();
