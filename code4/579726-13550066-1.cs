    public double Total    
    {
       get
       {
           return (double?)_Context.Sales
                                   .Where(t => t.Quantity > 0)
                                   .Sum(t => t.Quantity * t.Price) ?? 0; 
       }
    }
