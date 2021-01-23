    public class Order
    {
       public List<BasePosition> Positions { get; set; }
       public Order() { Positions = new List<BasePosition>(); }
    }
    
    public class BasePosition
    {
    
    }
    
    public class TextPosition : BasePosition
    {
       public string Text { get; set; }
    }
    
    public class ItemPosition : BasePosition
    {
       public int ItemId { get; set; }
       public string ItemName { get; set; }
    }
    
    public class SumPosition : BasePosition
    {
       public string Value { get; set; }
    }
