    public event EventHandler<SaveProgressEventArgs> SaveProgress
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
