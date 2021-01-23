    void MyInsertMethod()
    {
        using (var bulk = new SqlBulkCopy("MyConnectionString"))
        {
            bulk.DestinationTableName = "MyTableName";
            bulk.WriteToServer(GetRows().AsDataReader());
        }
    }
    
    class MyType
    {
        public string A { get; set; }
        public string B { get; set; }
    }
    
    IEnumerable<MyType> GetRows()
    {
        using (var file = System.IO.File.OpenText("MyTextFile"))
        {
            while (!file.EndOfStream)
            {
                var splitLine = file.ReadLine().Split(',');
    
                yield return new MyType() { A = splitLine[0], B = splitLine[1] };
            }
        }
    }
