    public interface ISortable
    {
        string SortString { get; }
    }
    public class ItemA : BaseContainer, ISortable
    {
        public string ItemAName { get; set; }
        public string SortString { get { return "ItemA: " + ItemAName; } }
    }
