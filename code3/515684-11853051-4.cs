    static void Main()
    {
        string search = "ame2";
        int rowIndex = 0;
        foreach(object row in GetData())
        {
            var accessor = ObjectAccessor.Create(row);
            int i = 1;
            while(true)
            {    
                try
                {
                    string colName = "column" + i++;
                    var val = (string) accessor[colName];
                    if(val.Contains(search))
                    {
                        Console.WriteLine("row {0}, col {1}, val {2}", rowIndex, colName, val);
                    }
                } catch
                { // exit loop
                    break;
                }
            }
            rowIndex++;
        }
    }
    // our opaque method
    static IEnumerable<dynamic> GetData()
    {
        yield return new {column1 = "1", column2 = "name", column3 = "somevalue"};
        yield return new {column1 = "2", column2 = "name2", column3 = "somevalue2"};
        yield return new {column1 = "3", column2 = "name3", column3 = "somevalue3"};
    }
