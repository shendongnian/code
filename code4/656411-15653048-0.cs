    [TestMethod]
    public void TestMethod2()
    {
      const string path = @"D:\KN_Vzorka_2012\VL816183.DBF";
    
      var connection = new OleDbConnection(string.Format("Provider=vfpoledb;Data Source={0};Extended Properties=\"dBase IV\";Locale Identifier=852;", Path.GetDirectoryName(path)));
      connection.Open();
    
      var command = new OleDbCommand(string.Format("select cast(MNO as varbinary(20)) as MNO FROM {0}", Path.GetFileName(path)), connection);
    
      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          var arr = (byte[])reader["MNO"];
          var str = Encoding.GetEncoding(852).GetString(arr);
    
        }
      }
    
      connection.Close();
    }
