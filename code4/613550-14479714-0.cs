    Action <Exception> myact = ( ) => {       
        throw new Exception("test");
    };
    
    Task myactTask = Task.Factory.StartNew(myact);
    try {
        myactTask.Wait();
        Console.WriteLine(myactTask.Id.ToString());
        Console.WriteLine(myactTask.IsCompleted.ToString());
    }
    catch(Exception ex) {
        throw ex;
    }
