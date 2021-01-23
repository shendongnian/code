    public class Content 
    {
     public int Key { get; set; }
     public int Order { get; set; }
     public string Title { get; set; }
     public static readonly Dictionary<String, String> IdToType = 
           new Dictionary<string, string>
     {
         {"00", "14"},
         {"1F", "11"},
         {"04", "10"},
        {"05", "09"},
        //etc.
     };
    }
