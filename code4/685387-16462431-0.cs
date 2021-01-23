    public interface IRoute
    {
        IUser user { get; set; } 
    }
    
    public interface IUser
    {
        IName name { get; set; }
    }
    
    public interface IName
    {
        [Required]
        string firstName { get; set; }
        [Required]
        string lastName { get; set; }
    }
