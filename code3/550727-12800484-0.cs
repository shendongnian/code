    public class StringAndOrder
    {
        public string String { get; set; }
        public double Order { get; set; }
    }
    List<StringAndOrder> list; //create with this structure instead
    var orderedStrings = list.OrderBy(item => item.Order).Select(item => item.String);
    
