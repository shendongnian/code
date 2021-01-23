    public void DoSomething(object parameter)
    {
      parameter = new Object(); // original object from the callee would be unaffected. 
    }
    
    public void DoSomething(ref object parameter)
    {
      parameter = new Object(); // original object would be a new object 
    }
