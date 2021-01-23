    public enum Genres
    {
        [Description("Rock!!!")]
        Rock, 
        Pop, 
        Disco, 
        Sport, 
        Talk, 
        Metal, 
        Hard_Rock, 
        Electro, 
        [Description("Classic Rock")]
        Classic_Rock
    }
    public class EnumItem
    {
        string Name { get; set; }
        string Description { get; set; }
        Enum EnumValue {get;set;}
        public static IEnumerable<EnumItem> GetValue(Type t)
        {
            // implementation using reflection/expression            
        }
    }
    // then you can use the retrieved list/whatever to do binding or so...
