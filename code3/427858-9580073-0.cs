    [SqlFunction(FillRowMethodName = "SplitToIntFillRow")]
    public static IEnumerable SplitToInt(SqlString str, SqlString separator)
    {
        var s = str.Value.Split(!separator.IsNull && separator.Value.Length > 0 ? separator.Value[0] : ',');
        var rtn = new List<int[]>(s.Length);
        for (int i = 0; i < s.Length; i++)
            rtn.Add(new[] { i, System.Convert.ToInt32(s[i]) });
        return rtn;
    }
    public static void SplitToIntFillRow(object row, out int InLevelOrder, out int Value)
    {
        InLevelOrder = ((int[])row)[0];
        Value = ((int[])row)[1];
    }
