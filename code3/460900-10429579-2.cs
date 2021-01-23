    public static void FillColumns(DataTable table, Type anonymousType) {
        PropertyInfo[] properties = anonymousType.GetProperties();
        foreach (PropertyInfo property in properties) {
            table.Columns.Add(property.Name);
        }
    }
