    public void Execute(Action action)
    {
        action.Invoke();
        
        // cleanup
    }
    in your webservice call:
    [WebMethod]
    public void DoSomething(string value)
    {
        Execute(() =>
        {
            // your real method body goes here
            // wrap every Webservice call in this Execute(...) block
            // and you are fine.
            Console.WriteLine(value);
        });
    }
