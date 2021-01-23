    public void Subscribe(Caller caller)
    {
        caller.MyEvent += (sender,e)=>{Console.WriteLine("I'm a anonymous method!"); }
    }
    
