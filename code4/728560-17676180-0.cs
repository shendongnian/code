    public string FullName
        get { return this.lastName + "," + this.firstName;
    }
    public persondetails(string lastName, string firstName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
