    public int MyProp { get; private set; }
    public bool InitMyProp(int value)
    { 
        if(!_set)
        {
            MyProp = value;
            _set = true;
            return true;
        }
        return false;  
     }
