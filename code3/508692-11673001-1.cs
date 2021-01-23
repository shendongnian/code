    public Form1()
    {
        InitializeComponent();
    
        Action<string> calltoaction;
        calltoaction = Doit;
        calltoaction("MyText1");
        calltoaction = Doit2;
        calltoaction("MyText2");
    }
    
    void Doit(string s)
    { Text = s; }
    
    void Doit2(string s)
    { textBox1.Text = s; }
