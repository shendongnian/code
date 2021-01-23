    Dictionary<Control, string> dic = new Dictionary<Control, string>()
    {
        {textBox1,"a"},
        {textBox2, "b"}
    };
    
    dic.ToList()
        .ForEach(x => this.GetType().GetMethod(x.Value, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
        .Invoke(this, new object[] { x.Key }));
    
    private void a(TextBox tb)
    {
        tb.Text = "test a";
    }
    
    
    private void b(TextBox tb)
    {
        tb.Text = "test b";
    }
