    public class Url
    {
         public static Url()
         { 
             QueryStringParser = new QueryStringParser();
         }
         public static QueryStringParser QueryStringParser { get; private set;}
    }
