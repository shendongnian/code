    public class MyViewModel
    {
        public Guid EmployeeId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    
        public ItemViewModel[] Items { get; set; }
    }
    
    public class ItemViewModel
    {
        public int TotalHours { get; set; }
        public int TotalMinutes { get; set; }
    }
