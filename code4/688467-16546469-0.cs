    [SqlFunction(DataAccess = DataAccessKind.None,
                    IsDeterministic = true,
                    SystemDataAccess = SystemDataAccesskind.None,
                    IsPrecise = true,
                    FillRowMethodName = "SplitFillRow",
                    TableDefinition = "s NVARCHAR(MAX)")]
    public static IEnumerable Split(SqlChars seperator, SqlStrign s)
    {
        if (s.IsNull)
        {
            return new string[0];
        }
        return s.ToString().Split(seperator.Buffer);
    }
    public static void SplitFillRow(object row, out SqlString s)
    {
        s = new SqlString(row.ToString());
    }
