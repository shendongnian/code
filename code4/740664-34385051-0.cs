    public static DataTable ConvertGenericListToDataTable<T>(this List<T> inputList)
    {
        var dt = new DataTable();
        using (var reader = ObjectReader.Create(inputList))
        {
            dt.Load(reader);
        }
        return dt;
    }
