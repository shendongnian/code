    public string FirstName { get; set; }
    public string FirstLetterOfName
    {
        get
        {
            // TODO: a minimum amount of error checking
            // might be good here for cases when FirstName
            // is null or an empty string
            return this.FirstName.Substring(1, 1);
        }
    }
