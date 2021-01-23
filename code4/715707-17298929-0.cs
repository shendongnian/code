The problem is that float point storage is not implemented for Azure Storage Tables. Changing the amount type to a double will fix the problem.
    public class MyEntity : TableServiceEntity
    {
        public string Title { get; set; }
    
        public string Description { get; set; }
    
        public double Amount { get; set; } // <-- Note change here!!!
    
        public DateTime CreatedAt { get; set; }
    
        public DateTime UpdatedAt { get; set; }
    }
