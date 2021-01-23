    public IEnumerable<string> Name
    {
        get
        {
            return new List<string>(Rows.Select(row => row.name)); //LINQ is more elegant
        }
    }
