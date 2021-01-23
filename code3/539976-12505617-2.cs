    public MyClass Data {get;set;}
    protected void Page_Load(object sender, EventArgs e)
    {
     if(Data!=null)
      Label1.Text = Data.Foo;
    }
