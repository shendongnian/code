    Dictionary<Type, SqlDbType> typeConversion = new Dictionary<Type, SqlDbType>()
    typeConversion.Add(typeof(String), SqlDbType.NVarChar);
    typeConversion.Add(typeof(int), SqlDbType.Integer);
    // you can even do this if you want
    typeConversion.Add(typeof(MyCustomImageClass), SqlDbType.VarBinary);
    
    public SqlDbType ConvertToSqlDbType(Type type)
    {
       return typeConversion[type];
    }
