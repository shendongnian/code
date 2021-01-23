    public static DataTable ConvertTo<T>(IList<T> list)
    {
        DataTable resultTable = CreateTable<T>();
        using(DataTable table = CreateTable<T>())
        {
             ....
             resultTable = table;
        }
        // 'table' object disposed already
        return resultTable ;
    }
