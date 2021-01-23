    public class User
    {
      public long UserId { get; set; }
      public String Nickname { get; set; }
      public virtual ICollection<TownResidents> TownResidents { get; set; }
    }
    public class Town
    {
      public long TownId { get; set; }
      public String Name { get; set; }
      public virtual ICollection<TownResidents> TownResidents { get; set; }
    }
    public class TownResidents
    {
      public long TownId { get; set; }
      public long UserId { get; set; }
      
      public virtual Town { get; set; } 
      public virtual User { get; set; } 
    }
