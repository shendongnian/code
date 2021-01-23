    private DateTime? orderDate = null;
    public DateTime OrderDate
    {
        get { return orderDate ?? DateTime.Now; }
        set { orderDate = value; }
    }
