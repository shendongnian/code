    public IEnumerable<ExpenseItem> ToFind(string trip)
    {
        return this.Where(e => e.Trip == trip);
    }
    
