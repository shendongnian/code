    public class Item
    {
        public int ItemId{get;set;}
        ...
        public virtual ICollection<ItemInBoard> ItemsInBoard { get; set; }
    }
    public class Board
    {
        public int BoardId{get;set;}
        ...
        public virtual ICollection<ItemInBoard> ItemsInBoard { get; set; }
    }
    public class ItemInBoard
    {
        [Key, Column(Order = 1)]
        public int ItemId{get;set;}
        [Key, Column(Order = 2)]
        public int BoardId{get;set;}
        public DateTime CreatedOnDate{get;set;}
        public virtual Item Item{get;set;}
        public virtual Board Board{get;set;}
    }
