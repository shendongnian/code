    // wrong
    ITask[] TaskAry = new ITask[] { }; 
    TaskAry[0] = new TaskClass().Do();
    
    // correct
    ITask[] TaskAry = new ITask[] { new TaskClass() };  
    TaskAry[0].Do();
    // better
    // TaskComposite constructor accepts param array
    TaskComposite tc = new TaskComposite(new TaskClass()); 
    tc.Do(); // execute passed instance of TaskClass
