    private static string _Val;
    public static string Val
    {
        get { return _Val; }
        set { _Val = value; }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {            
        Val = label.Text;
        Thread staThread = new Thread(new ThreadStart (myMethod));
        staThread.ApartmentState = ApartmentState.STA;
        staThread.Start();
    }
    public static void myMethod()
    {
        Clipboard.SetText(Val);
    }
