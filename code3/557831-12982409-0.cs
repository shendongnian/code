    private string _lastName;
    public string LastName
    {
        get { return _lastName; }
        set
        {
            if (value == "Johnson" || value == "Smith" || value == "Roberts")
            {
                _lastName = value;
            }
            else
            {
                // Do something here. Maybe set a default.  Maybe throw an exception. Whatever.
            }
        }
    }
