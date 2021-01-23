    public decimal Amount
    {
        get { return (decimal)self.Attribute("Amount"); }
        set { self.SetAttribute("Amount", value); }
    }
