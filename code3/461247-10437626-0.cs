    public DateTime ModifiedDateTime { get; set; }
    private DateTime _addedDateTime;
    public DateTime AddedDateTime {
        get { return _addedDateTime; }
        set 
        {
            if (ModifiedDateTime == DateTime.MinValue)
            {
                ModifiedDateTime = _addedDateTime = value;
            };
        }
    }
    ...
    var test = new Test 
    { 
       AddedDateTime = DateTime.Now
    };
