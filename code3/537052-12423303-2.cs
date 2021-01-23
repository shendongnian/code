    Hotkey hk = new Hotkey();
    hk.KeyCode = Keys.1;
    hk.Windows = true;
    hk.Pressed += delegate { Console.WriteLine("Windows+1 pressed!"); };
    if (!hk.GetCanRegister(myForm))
    { 
        Console.WriteLine("Whoops, looks like attempts to register will fail " +
                          "or throw an exception, show error to user"); 
    }
    else
    { 
        hk.Register(myForm); 
    }
    // .. later, at some point
    if (hk.Registered)
    { 
       hk.Unregister(); 
    }
