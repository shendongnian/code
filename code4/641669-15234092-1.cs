    Dictionary<string, Type> typeLookup;
    // In your constructor:
    public YourClass()
    {
        typeLookup.Add("id", typeof(int));
        typeLookup.Add("name", typeof(string));
        typeLookup.Add("price", typeof(decimal));
        typeLookup.Add("shipping", typeof(decimal));
    }
