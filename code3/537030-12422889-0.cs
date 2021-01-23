    public enum TYPE {
        City = 7,
        Street = 8
    };
    
    var types = Get(TYPE.City.ToString("00")).ToList();
