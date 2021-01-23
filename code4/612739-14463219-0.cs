    public object this[string key]
    {
        get
        {
            var dict = myObject as IDictionary;
            if (dict == null) {
                return null;
            }
            if (dict.Contains()) {
                return dict[key];
            }
            return null;
        }
        set
        {
            var dict = myObject as IDictionary;
            if (dict != null) {
                dict[key] = value;
            }
        }
    }
