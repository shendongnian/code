    // Conversion list of used types
    Dictionary<Type, SqlDbType> typeConversion = new Dictionary<Type, SqlDbType>();
    typeConversion.Add(typeof(String), SqlDbType.NVarChar);
    typeConversion.Add(typeof(Int32), SqlDbType.Integer);
    // you can even do this if you want
    typeConversion.Add(typeof(MyCustomImageClass), SqlDbType.VarBinary);
    typeConversion.Add(typeof(MyOtherNiceClass), SqlDbType.NVarChar);
    
    // In the method
    SqlCommand command = new SqlCommand("SELECT * FROM MyTable WHERE mycolumn = @Value");
    command.Parameters.Add(new SqlParameter("@Value", typeConversion[whateverobject.GetType()]) { Value = whateverobject } );
