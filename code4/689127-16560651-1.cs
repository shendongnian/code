    private List<int> list;
    public List<int> List
    {
        get
        {
            if (this.list == null)
            {
                this.list = new List<int> { 1, 2, 3, 4 };
            }
            return this.list;
        }
        set
        {
            this.list = value;
        }
    }
