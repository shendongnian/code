    [NotMapped]
    public virtual string Version
    {
        get
        {
            return this.GetProperty(PropertyNameVersionConst) == null
                        ? null
                        : this.GetProperty(PropertyNameVersionConst).StringValue;
        }
        set
        {
            this.SetProperty(PropertyNameVersionConst, value);          
        }
    }
