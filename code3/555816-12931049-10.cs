    private static IDictionary<Towns, int> GetTown(Towns town)
    {
        switch(town)
        {
            case Towns.Edinburgh:
                return new Dictionary
                {
                    { Key = Aberdeen, Value = 129 },
                    { Key = Ayr, Value = 79 },
                    { Key = FortWilliam, Value = 131 },
                    { Key = Glasgow, Value = 43 },
                    ...
                }
            case Towns.Ayr
                ...
            ...
            default:
               throw new ArgumentException(
                   string.Format("{0} not implemented", town),
                   "town"); 
        };
    }
