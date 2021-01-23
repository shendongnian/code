    public class HelperClass
    {
        private readonly KeyValuePair<string, double[]> Item;
        [Bindable]
        public string Key { get { return Item.Key; } }
        [Bindable]
        public double Value1 {get { return Item.Value[0]; } }
        [Bindable]
        public double Value2 {get { return Item.Value[1]; } }
        public HelperClass(KeyValuePair<string, double[]> item)
        {
            this.Item = item;
        }
    }
    public List<HelperClass> Convert(Dictionary<string, double[]> items)
    {
        var result = new List<HelperClass>(items.Count);
        foreach(var item in items)
            result.Add(new HelperClass(item));
        return result;
    }
