    public static class ExpressionExtensions {
      public static IEnumerable<T> Select<T>(this IEnumerable<T> self, string expression) {
        var table = new DataTable();
        table.Columns.Add("Value", typeof(T));
        foreach (var item in self) {
          var row = table.NewRow();
          row["Value"] = item;
          table.Rows.Add(item);
        }
        return table.Select(expression).Select(row => (T)row["Value"]);
      }
    }
