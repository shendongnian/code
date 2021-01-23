    /// <summary>
    /// 
    /// </summary>
    /// <param name="DT"></param>
    /// <param name="ColumnNames">Columns to check in affected table.</param>
    /// <param name="ItemtoChecks">Values to check in affected column.</param>
    /// <returns></returns>
    public static bool TableContains(this DataTable DT, string[] ColumnNames, object[] ItemtoChecks)
    {
      var result = from row in DT.AsEnumerable()
                   where ColumnNames.All(
                   r => row.Field<object>(r).ToString() == Convert.ToString(
                     ItemtoChecks[ColumnNames.ToList()
                     .FindIndex(p => p.Equals(r, StringComparison.OrdinalIgnoreCase))]))
                   select row;                   
      return (result.Count() > 0);
    }
