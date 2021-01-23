    class Thing
    {
        public int Item1 { get; set; }
        public int Item2 { get; set; }
        public int Item3 { get; set; }
        public int Item4 { get; set; }
    }
    static void Main(string[] args)
    {
        var myList = new List<int> {100, 50, 200, 30};
        var objWithProperties = new Thing();
        AssignProperties(objWithProperties, "Item", 1, myList);
    }
    private static void AssignProperties(object item, string propertyName, int startIndex, IEnumerable values)
    {
        int index = startIndex;
        if (item == null) throw new ArgumentNullException("item");
        foreach (var value in values)
        {
            string currentPropertyName = propertyName + index;
            var property = item.GetType().GetProperty(currentPropertyName);
            if (property == null)
            {
                throw new IndexOutOfRangeException("Property " + currentPropertyName + " does not exist on type " + item.GetType());
            }
            property.SetValue(item, value);
            index++;
        }
    }
