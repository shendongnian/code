    using System.Data.SqlServerCe;
    using System.IO;
      string folderPath="D:\\Compact_DB"
      string connectionString;
      string fileName =folderPath+"\\School.sdf";
      string password = "12345";
    
      if (File.Exists(fileName))
      {
        File.Delete(fileName);
      }
    
      connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'",    fileName, password);
      SqlCeEngine obj_ceEngine = new SqlCeEngine(connectionString);
      obj_ceEngine.CreateDatabase();
