    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName
    {
        get { return String.Format("{0}-{1}", FirstName, LastName); }
        set 
        {
            // check if value format valid
            var names = value.Split('-');
            FirstName = names[0];
            LastName = names[1];
        }
    }
