    internal List<string> ChangedFields = new List<string>();
    private string _name;
    public string Name
    {
        get { return _name; }
        set {
            ChangedFields.Add("Name");
            _name = value;
        }
    }
