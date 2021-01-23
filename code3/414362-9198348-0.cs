    object IAppContextItem.Element
    {
        get { return this.Element; }
        set
        {
            if (!(value is T))
                throw // ... some exception
            this.Element = (T)value;
        }
    }
