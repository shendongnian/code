    string sdfPath  = @"c:\temp\s1234-1234\mydatabase.sdf";
    var _connectionString  = string.Format("Data Source = {0}; Password = {1}", sdfPath, password);
    using (SqlCeEngine en = new SqlCeEngine(_connectionString))
    {
        en.CreateDatabase();
    }
    return true;
