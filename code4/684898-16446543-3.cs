    public Example2()
    {
        Action<int> setter = this.GetX;
        Func<int> getter = this.SetX;
    }
    private int GetX() { return 0; }
    private void SetX(int value) { }
    public int X 
    {
        get { return GetX(); } 
        set { SetX(value); } 
    }
