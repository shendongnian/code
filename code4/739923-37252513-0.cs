    public static DataTable Enum2DataTable<T>()
    {
        DataTable EnumTable = new DataTable();
        EnumTable.Columns.Add(new DataColumn("Value", Enum.GetUnderlyingType(typeof(T))));
        EnumTable.Columns.Add(new DataColumn("Display", System.Type.GetType("System.String")));
        DataRow EnumRow;
        foreach (T E in Enum.GetValues(typeof(T)))
        {
            EnumRow = EnumTable.NewRow();
            EnumRow["Value"] = E;
            EnumRow["Display"] = E.ToString();
            EnumTable.Rows.Add(EnumRow);
        }
        return EnumTable;
    }
