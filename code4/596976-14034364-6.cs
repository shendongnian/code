    public static int Insert(string cs, string table, string[] colNames, object[] paramValues)
    {
        ......
              string strCommand = string.Format(
                    "INSERT INTO {0} ({1}) VALUES ({2})", table, 
                    colNames.Aggregate((a, b) => (a + ", " +b)),
                    colNames.Select(n => "@" + n).Aggregate((a, b) => (a + ", " + b)));
        .....
                for(int x = 0; x < colNamesNames.Length; x++)
                    com.Parameters.AddWithValue("@" + colNames[x], paramValues[x]);
    }
