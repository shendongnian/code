    public Main()
    {
        DoWork();
        Timer1.Enabled = true;
    }
    protected void Timer1_Tick(object sender, args e)
    {
        DoWork();
    }
