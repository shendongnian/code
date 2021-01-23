    public class MyClass
    {
        public int Key { get; set; }
    }
    IQueryable<MyClass> source = // Get source data (DataContext/ObjectContext/ISession etc.)
    var excludedKeys = new List<int> { 1, 3, 11 };
    var result = source.Exclude(item => item.Key, excludedKeys);
