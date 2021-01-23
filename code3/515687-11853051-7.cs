    static void Main()
    {
        string search = "ame2";
        int rowIndex = 0;
        string[] names = null;
        TypeAccessor accessor = null;
        foreach(object row in GetData())
        {
            if(names == null)
            { // first row; get the property-names and build an accessor
                names = (from prop in row.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                         where prop.PropertyType == typeof (string)
                         select prop.Name).ToArray();
                accessor = TypeAccessor.Create(row.GetType());
            }
            
            foreach(var name in names)
            {
                var val = accessor[row, name] as string;
                if(val != null && val.Contains(search))
                {
                    Console.WriteLine("row {0}, col {1}, val {2}", rowIndex, name, val);
                }
            }
            rowIndex++;
        }
    }
    static IEnumerable<dynamic> GetData()
    {
        yield return new {column1 = "1", column2 = "name", column3 = "somevalue"};
        yield return new {column1 = "2", column2 = "name2", column3 = "somevalue2"};
        yield return new {column1 = "3", column2 = "name3", column3 = "somevalue3"};
    }
