    public event EventHandlerType EventHandlerName
    {
        add
        {
            this._privateControl.EventHandlerName += value;
        }
        remove
        {
            this._privateControl.EventHandlerName -= value;            
        }
    }
