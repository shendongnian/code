      string connectionString;
      string fileName = “ArcaneCode.sdf”;
      string password = “arcanecode”;
 
      connectionString = string.Format(
        “DataSource=\”{0}\”; Password=’{1}’”, fileName, password);
      SqlCeEngine en = new SqlCeEngine(connectionString);
      en.CreateDatabase();
