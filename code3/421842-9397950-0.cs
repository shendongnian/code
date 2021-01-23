    while (reader.Read()) {
    
        var fieldCount = reader.FieldCount;
        for (int i = 0; i < fieldCount; i++) {
               backupFile.Write("\"");
               backupFile.Write(reader.GetValue(i).ToString());
               backupFile.Write("\";");;
        }
        backupFile.WriteLine();
     }
