    int _num;
    public int num
    {
        get { return _num; }
        set 
        {
            if(value != _num)
            {
                _num = value;
                numModified = DateTime.Now;
            }
        }
    }
    
    public DateTime numModified { get; private set; }
