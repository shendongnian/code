    internal class SomeType
    {
        public string StringValue { get; set; }
    }
    List<SomeType> l = new List<SomeType>
        {
            new SomeType {StringValue = "bbbbb"},
            new SomeType {StringValue = "cccc"},
            new SomeType {StringValue = "aaaa"},
            new SomeType {StringValue = "eeee"},
        };
    var asc = l.OrderBy("StringValue", "ASC");
    var desc = l.OrderBy("StringValue", "DESC");
