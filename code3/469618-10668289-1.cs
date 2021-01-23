    public IEnumerable<string> Name
    {
        get
        {
            return Rows.Select(row => row.name); //LINQ is more elegant here
        }
    }
