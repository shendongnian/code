    // Assume your list (List<string>) is named "myList"
    // Please put the next line in an external string resource...
    string selectStatement = "SELECT Column1 FROM Table1 WHERE Column1 IN ({0})";
    StringBuilder stringBuilder = new StringBuilder("(");
    foreach(string colName in myList)
        stringBuilder.Append(String.Format("'{0}',", colName));
    stringBuilder.Append(")");
    return String.Format(selectStatement, stringBuilder.ToString().Replace(",)", ")");
    
