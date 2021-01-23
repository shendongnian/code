    private void MyPrivateHandler(Object sender, EventArgs e)
    {
        Console.WriteLine("I'm a private method!");
    }
    public void Subscribe(Caller caller)
    {
        caller.MyEvent += this.MyPrivateHandler;
    }
