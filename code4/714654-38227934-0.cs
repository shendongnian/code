    public string ReadString(IDataReader reader, string columnName) {
    string myString = "";
    var index = reader.GetOrdinal(columnName);
    var fieldType = reader.GetFieldType(index);
    if (fieldType.FullName.Contains("Guid"))
    {
    myString = reader.IsDBNull(index) ? "" : reader.GetGuid(index).ToString();
    }
    else
    {
    myString = reader.IsDBNull(index) ? "" : reader.GetString(index);
    }
    return myString;
    }
