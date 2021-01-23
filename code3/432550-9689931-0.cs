    private Core1 newcore = new Core1();
    public Core1 Core
    {
        get { return newcore; }
        set { newcore = value; }
    }
    public void DoSmthWithCore()
    {
        newcore.DoSmth();
    }
