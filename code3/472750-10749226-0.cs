    public bool MinReached()
    {
        return this.Details.Count >= 10;
    }
    
    public void FillDetails()
    {
        for (int i = Details.Count; i <= 10; i++)
            this.Add(new City.Detail());
    }
