    public class Entity
    {
        public int MessageType { get; set; }
        public string Message { get; set; }
        public List<EntityValue> Value { get; set; }
    }
    
    public class EntityValue
    {
        public int listId { get; set; }
        public string listName { get; set; }
        public List<ItemInList> itemInList { get; set; }
    }
    
    public class ItemInList
    {
        public DateTime? fromDate { get; set; }
        public string fromLocation { get; set; }
        public string toLocation { get; set; }
        public string originalRequest { get; set; }
        public DateTime creationDate { get; set; }
        public int typeId { get; set; }
    }
