    public interface IItem
    {
        string ItemName { get; set; }
    }
    public class ItemA : BaseContainer, IItem
    {
        public string ItemName { get; set; }
    }
    public class ItemB : BaseContainer, IItem
    {
        public string ItemName { get; set; }
    }
