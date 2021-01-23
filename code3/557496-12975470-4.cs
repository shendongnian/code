    private DataTable RemoveUnwanted(DataTable source)
    {
        var rowsEnu = source.Rows.GetEnumerator();
        while (rowsEnu.MoveNext())
        {
            ((DataRow)rowsEnu.Current)["Name"] = ((DataRow)rowsEnu.Current)["Name"].ToString().StartsWith("null") ? string.Empty : ((DataRow)rowsEnu.Current)["Name"];
        }
        return (from i in source.AsEnumerable()
                where !(i.ItemArray.All(o => string.IsNullOrEmpty(o.ToString())))
                select i).CopyToDataTable();
    }
