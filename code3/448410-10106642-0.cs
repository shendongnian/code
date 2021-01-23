    Queue<Func<string>> actions = new Queue<Func<string>>();
    if(dropboxListID.Text =="m1")
    {
     actions.Enqueue(method1Imp);
    }
    if(dropboxListID.Text = "m2")
    {
     action.Enqueue(method2Imp);
    }
    ...
    Sometime Later when you're ready to process these
    ...
    string txt = "";    
    while(actions.Count >0)
    {
     var method = actions.Dequeue();
     txt = method();
    }
