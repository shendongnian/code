    public string FullName
    {
        get
        {
            return string.IsNullOrEmpty(FirstName) ? LastName 
                : string.IsNullOrEmpty(LastName) ? FirstName : FirstName + " " + LastName;
        }
    }
