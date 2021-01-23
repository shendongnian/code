    public static IList<string> MyList { get { return myList; } }
    private static readonly ReadOnlyCollection<string> myList = 
        ReadOnlyCollection<string>(new[]
        {
            "Item 1", "Item 2", "Item 3"
        });
