    public class Position
        {
            public int Id { get; set; }
    
            public string CompanyName { get; set; }
    
            public bool IsCurrentRole { get; set; }
    
            public string Summary { get; set; }
    
            public string Title { get; set; }
    
            public int? StartMonth { get; set; }
    
            public int? StartYear { get; set; }
    
            public int? EndMonth { get; set; }
    
            public int? EndYear { get; set; }
    
            public virtual User User { get; set; }
            public int UserId { get; set; }
        }
