    public double Total    
    {
       get
       {
           return _Context.Sales
                          .Where(t => t.Quantity > 0)
                          .Sum(t => (double?)(t.Quantity * t.Price)) ?? 0; 
       }
    }
