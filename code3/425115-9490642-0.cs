    void Main()
    {
        Side side;
        Enum.TryParse("Buy", out side).Dump();
        side.Dump();
    }
    
    public enum Side{Buy, Sell}
