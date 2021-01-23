    public interface IDataValuesProvider
    {
        IEnumerable<object> GetDataValues(bool includeAll);
    }
    ... on the class:
    public class StockItem : IDataValuesProvider
    {
        public int Id { get; set; }
        public string ItemName {get; set;}
        [Browsable(false), DisplayName("Ignore")]
        public string propA {get; set;}
        [ReadOnly(true)]
        public string Zone { get; set; }
        public string Size {get; set;}
        [DisplayName("Nullable")]
        public int? Foo { get; set; }
        public int OnHand {get; set;}
        public string ProdCode {get; set;}
        [Browsable(false)]
        public string propB { get; set; }
        public DateTime ItemDate {get; set;}
        // IDataValuesProvider implementation
        public IEnumerable<object> GetDataValues(bool IncludeAll)
        {
            List<object> values = new List<object>();
            values.AddRange(new object[] {Id, ItemName });
            if (IncludeAll) values.Add(propA);
            values.AddRange(new object[] { Zone, Size, Foo, OnHand, ProdCode });
            if (IncludeAll) values.Add(propB);
            values.Add(ItemDate);
            return values;
        }
    }
