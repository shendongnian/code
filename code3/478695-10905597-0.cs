    public int MyRandomFunction(string seedString)
    {
        int hashCode = seedString.GetHashCode(); // Always returns the same integer based on a string
        Random myGenerator = new Random(hasCode);
        return myGenerator.Next(10000, 99999); // Returns a number between 10000 and 99999, ie 5 digits
    }
