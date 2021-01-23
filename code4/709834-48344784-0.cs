    public interface IThing
    {
        string Name { get; set; }
    }
    public class Thing : IThing
    {
       public int Id { get; set; }
       public string Name { get; set; }
    }
