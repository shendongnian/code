    private static IDictionary<int, string> GetGridViewFieldNames(object grid)
    {
        var names = new Dictionary<int, string>();
        var view = grid as GridView;
        if (view != null)  {
            for (var i = 0; i < view.Columns.Count; i++)  {
                var field = view.Columns[i] as BoundField;
                if (field != null)  {
                    names.Add(i, field.DataField);
                }
            }
        }
        return names;
    }
