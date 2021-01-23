    private static string FindLongStrings(object testObject)
        {
            foreach (PropertyInfo propInfo in testObject.GetType().GetProperties())
            {
                foreach (ColumnAttribute attribute in propInfo.GetCustomAttributes(typeof(ColumnAttribute), true))
                {
                    if (attribute.DbType.ToLower().Contains("varchar"))
                    {
                        string dbType = attribute.DbType.ToLower();
                        int numberStartIndex = dbType.IndexOf("varchar(") + 8;
                        int numberEndIndex = dbType.IndexOf(")", numberStartIndex);
                        string lengthString = dbType.Substring(numberStartIndex, (numberEndIndex - numberStartIndex));
                        int maxLength = 0;
                        int.TryParse(lengthString, out maxLength);
                        string currentValue = (string)propInfo.GetValue(testObject, null);
                        if (!string.IsNullOrEmpty(currentValue) && currentValue.Length > maxLength && lengthString!="max")
                            return testObject.GetType().Name + "." + propInfo.Name + " " + currentValue + " Max: " + maxLength;
                    }
                }
            }
            return "";
        }
    foreach (object insert in dtx.GetChangeSet().Inserts)
                {
                    string result = FindLongStrings(insert);
                    if (string.IsNullOrEmpty(result) == false)
                    {
                        responseBuilder.Append(result);
                    }
                }
