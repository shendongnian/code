    var _testConx = new OracleConnection(_testConnectionString);
    var rezList = new List<Type>();
    string _GetSQL = @"SELECT STATEMENT";
    var dbCommand = new OracleCommand(_GetSQL , _testConx);
    dbCommand .CommandType = CommandType.Text;
    var reader = dbCommand .ExecuteReader();
    while (reader.Read())
    {
       var rez = new Type();
       rez.Field1= TryGetInt(reader.GetOracleValue(0));
       rez.Field2= TryGetString(reader.GetOracleValue(1));
    
       rezList.Add(rez);
    }
    return rezList;
