    class MyCollection<T> : Collection<T>
    {
        public MyCollection(DataTable dataTable, Func<DataRow, T> itemsFactory)
            : base(dataTable.Rows.Cast<DataRow>().Select(row => itemsFactory(row)).ToList())
        {
        }
    }
    var firstClassCollection = new MyCollection<FirstClass>(dataTable, row => new FirstClass 
    {
        Title = (String)row["Title"],
        Url = (String)row["Url"]
    });
