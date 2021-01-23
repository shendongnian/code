    dataReader.GetInt("columnName1")
    dataReader.GetString("columnName3")
    dataReader.GetFloat("columnName3")
    public static int GetInt(this IDataReader r, string columnName)
    {
        return Convert.ToInt32(r[columnName]);
    }
