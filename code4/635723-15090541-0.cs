    class Style
    {
         //some properties
    }
    class Slope
    {
        //some properties        
    }
    struct Config
    {
        String  Range {get; set;}
        Double Step { get; set; }
    }
    Dictionary<Tuple<Style, Slope>, Config> conf = new Dictionary<Tuple<Style, Slope>, Config>();
    public Config GetConfig(Style someStyle, Slope someSlope)
    {
        return conf[Tuple.Create(someStyle, someSlope)];
    }
