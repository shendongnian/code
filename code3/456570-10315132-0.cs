    public class User
    {
        public string ID { get; set; }//.... All User Attributes AND
    
    }
    
    public class TodoList
    {
        public string Id { get; set; }
        public User owner { get; set; }
        
    }
    
    public class TodoListItem
    {
        public string ItemID { get; set; }
        public TodoList parent { get; set; }
        public string ItemDescription { get; set; }
        public bool IsCompleted { get; set; }
    }
    
