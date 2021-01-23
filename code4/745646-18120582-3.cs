    class MyReturn
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
    MyMethod(new MyReturn());
    void MyMethod(MyReturn ret)
    {
        ret.Text = "Hello";
        ret.Value = 10;
    }
    
