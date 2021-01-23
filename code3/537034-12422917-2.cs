    public static class TYPE
    {
        public static readonly string City = "07";
        public static readonly string Street = "08";
    }
    // Usage:
    var types = Get(TYPE.City).ToList(); // this evaluates to .Get("07")
