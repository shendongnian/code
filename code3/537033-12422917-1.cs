    public static class TYPE
    {
        public static string City = "07";
        public static string Street = "08";
    }
    // Usage:
    var types = Get(TYPE.City).ToList(); // this evaluates to .Get("07")
