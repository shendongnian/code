    private string _name;
    public string Name
    {
        get
        {
            if (string.IsNullOrEmpty(_name))
            {
                return _name;
            }
            var charArray = _name.ToCharArray();
            charArray[0] = char.ToUpper(charArray[0]);
            return new string(charArray);
        }
        set { _name = value; }
    }
