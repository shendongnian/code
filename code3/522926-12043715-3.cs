    //no return value, no parameters; ShowWindow(), HideWindow(), etc
    //Understand that many built-in control methods are not virtual and so you can't 
    //override them to do this; you must either hide them or ensure the caller is
    //checking for cross-threading.
    public void MyWindowMethod()
    {
       if(InvokeRequired)
          this.Invoke(new Action(MyWindowMethod));
       else
       {
          //main logic
       }
    }
    
    //Input but no return; SetTitle("My Title")
    public void MyWindowMethod2(string input)
    {
       if(InvokeRequired)
          this.Invoke(new Action<string>(MyWindowMethod2), input);
       else
       {
          //main logic
       }
    }
    
    //inputs and outputs
    public string MyWindowMethod3(string input)
    {
       if(InvokeRequired)
          return (string)(this.Invoke(new Func<string, string>(MyWindowMethod3), input));
       else
       {
          //main logic   
       }
    }
