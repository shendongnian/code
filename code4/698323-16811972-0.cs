    private MySpclClass myObject;
    public MySpclClass MyObject
    {
        get
        {
            if (this.myObject == null)
                this.myObject = new MySplClass();
            return this.myObject;
        }
    }
