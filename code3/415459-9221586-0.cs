    private List<Shot> _shots;
    
    public List<Shot> Shots
    {
        get 
        { 
            if (_shots == null) 
            {
                _shots = new List<Shot>();
            }
            return _shots;
        }
        set
        {
            _shots = value;
        }
    }
