    public class MyClass
    {
        public string Severity { get; set; }
        public int OtherValue { get; set; } 
    }
    MyClass myClass = new MyClass() { OtherValue = 1, Severity = "Information" };
    Database db = DatabaseFactory.CreateDatabase();
    if (!db.SupportsParemeterDiscovery)
    {
        throw new InvalidOperationException("Database does not support parameter discovery");
    }
    string spName = "MySP";            
    DbCommand cmd = db.GetStoredProcCommand(spName);
    db.DiscoverParameters(cmd);
    foreach (DbParameter parameter in cmd.Parameters)
    {
        if (parameter.Direction != System.Data.ParameterDirection.Output && 
            parameter.Direction != System.Data.ParameterDirection.ReturnValue)
        {
            PropertyInfo pi = myClass.GetType().GetProperty(
                parameter.ParameterName.Substring(1)); // remove @ from parameter
            if (pi != null)
            {
                parameter.Value = pi.GetValue(myClass, null);
            }
        }
    }
            
    int value = (int)db.ExecuteScalar(cmd);
