    private string _Item;
    
    public string Item
    {
        get
        {
            return _Item;
        }
        set
        {
            _Item = WebUtility.HtmlDecode(value);
        }
    }
