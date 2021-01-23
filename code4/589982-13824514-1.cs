    public Alert this[int index]
    {
        get ...
        set
        {
            lock(this)
            {    
                this.List[index] = value;
            }
        }
    }
