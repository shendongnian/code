    public static DataSet GetEnums()
    {
        DataSet data = new DataSet();
        DataTable table = new DataTable();
        table.Columns.Add("Name");
        data.Tables.Add(table);
        DataRow r;
        foreach (var e in Enum.GetValues(typeof(SurfaceType)))
        {
            r = data.Tables[0].NewRow();
            r["Name"] = e.ToString();
            data.Tables[0].Rows.Add(r);
        }
        return data;
    }
