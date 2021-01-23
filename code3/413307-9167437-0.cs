    public event SaveProgress
    {
        add
        {
               lock(_obj.Event)
                    _obj.Event += value;
        }
        remove
        {
               lock(_obj.Event)
               _obj.Event  -= value;
        }
    }
