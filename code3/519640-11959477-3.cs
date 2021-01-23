    public Form2(Form1 frm1)
    {
        InitializeComponent();
    }
    public MyObject GetMyObject()
    {
        return obj;
    }
    MyObject obj;
    private void button1_Click(object sender, EventArgs e)
    {
        obj = new MyObject();
        obj.Value1 = 102;
        obj.Value2 = 50;
    }
