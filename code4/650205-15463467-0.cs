    public string FirstName
    {
        get
        {
           return fname
        }
        set
        {
           if (value.ToCharArray().Count(s => Char.IsDigit(s)) > 0)
           {
               throw new Exception("Only letters allowed");
           }
           fname = value;
        }
    }
