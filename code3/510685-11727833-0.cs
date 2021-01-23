    public bool HasChanges
    {
        get
        {
            return myData == null ? false : this.myData.HasChanges();
        }
    }
