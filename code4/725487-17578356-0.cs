    private string firstName;
    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("FirstName");
            firstName = value;
        }
    }
