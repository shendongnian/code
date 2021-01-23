    public enum ContentKey
    {
        Menu = 0,
        Article = 1,
        FavoritesList = 2
    }
    
    static bool Check(string pk)
    {
        return Enum.IsDefined(typeof(ContentKey), pk);
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine(Check("Menu"));
        Console.WriteLine(Check("Foo"));
    }
