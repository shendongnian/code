    private string _name;
    
    public string Name
    {
        get { return _name; }
        set
        {
            _slug = value.ToUrlSlug(); // the magic happens here
            _name = value; // but don't forget to set your name too!
        }
    }
    
    private string _slug;
    
    public string Slug
    {
        get { return _slug; }
        private set { _slug = value; }
    }
