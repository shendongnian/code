    public static bool operator true(YourClass x)
    {
        return whateveryouwant || somethingelse;
    }
    public static bool operator false(YourClass x)
    {
        return blah != 1 || x.Value != 5;
    }
