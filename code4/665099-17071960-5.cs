    public class MyClass
    {
        public string Severity { get; set; }
        public int OtherValue { get; set; } 
    }
    MyClass myClass = new MyClass() { OtherValue = 1, Severity = "Information" };
    Database db = DatabaseFactory.CreateDatabase();
    string spName = "MySP";            
    DbCommand cmd = db.GetStoredProcCommand(spName);
    db.PopulateCommandValues(cmd, myClass); 
    int value = (int)db.ExecuteScalar(cmd);
