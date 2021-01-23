    private DateTime? createdDate = null;
    public DateTime CreatedDate
    {
        get { return createdDate ?? DateTime.Now; }
        set { createdDate = value; }
    }
