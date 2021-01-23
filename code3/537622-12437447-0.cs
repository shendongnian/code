    private string lastModified; // instance variable
    public string LastModified 
    {
        get { return this.lastModified; }
        set 
        { 
            long ms = Int64.Parse(value);
            var date = new DateTime(1970, 1, 1).AddSeconds(ms);
            date = date.ToLocalTime();
            this.lastModified = date.ToString("HH_mm_yyyy");
        }
    }
