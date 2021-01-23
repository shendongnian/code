    public static string GetObjectTypeOrDefault(this MyObject myObject)
    {
        if(myObject.IsA) return "A";
        if(myObject.IsB) return "B";
        if(myObject.IsC) return "C";
        return "D";
    }
