    // returns true if the object evaluates to true
    public static bool operator true(YourClass x)
    {
        return x != null;
    }
    // returns true if the object evaluates to false
    public static bool operator false(YourClass x) 
    {
        return x == null;
    }
