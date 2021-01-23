    public static string GetString(this IDataReader r, string columnName)
    {
    }
    public static float GetFloat(this IDataReader r, string columnName)
    {
    }
-
    // Compare 
    // r.GetInt("")12345678 characters saved ;)
    // to 
    // GetValue<int>(r[""])
    //             ^^^^^^^^
