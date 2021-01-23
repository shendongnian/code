    private string _name = string.Empty;
    public string Name 
    { 
        get { return _name; }
        private set 
        {
            TextInfo txtInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            _name = txtInfo.ToTitleCase(value);
        }
    }
