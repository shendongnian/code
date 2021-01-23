    public class GroupOfitems
    {
        public string groupName { get; private set; }
        public List<Item> ItemList { get; private set; }
        public GroupOfitems()
        {
            this.ItemList = new List<Item>();
        }
        public GroupOfitems(string groupName, List<Item> itemList)
        {
            this.groupName = groupName;
            this.ItemList = itemList;
        }
    }
