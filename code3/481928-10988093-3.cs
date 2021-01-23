    public class Gen 
    { 
       // you could have private members here and these properties to wrap them
       public string Id { get; set; } 
       public string GraphFile { get; set; } 
    } 
    
    public static void process(Gen gen) 
    {
       // possible because of public class with static public members
       using(StreamWriter mgraph = new StreamWriter(gen.GraphFile))
       {
         // do your processing...
       }
    }
