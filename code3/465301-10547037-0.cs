    // old
    ITask[] TaskAry = new ITask[] { }; 
    TaskAry[0] = new TaskClass().Do();
    
    // correct
    ITask[] TaskAry = new ITask[] { new TaskClass() };  
    TaskAry[0].Do();
