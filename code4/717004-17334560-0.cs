    OdbcDataReader reader = CMD.ExecuteReader();
    reader.Read();
    if (reader.IsDBNull(0) == false)
    {
        try {
            checkBox1.Checked = reader.GetBoolean(0);
        }
        catch ( InvalidCastException e ) {
            object doubleCheck = reader.GetValue(0);
            Console.WriteLine( "Tried to cast this type: " + doubleCheck.GetType() );
        }
    }
