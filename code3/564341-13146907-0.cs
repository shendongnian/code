    var temp = new Person[]{ p }
    svc.DoOperation(temp);
    
    // This writes the old value not the one changed by the service.
    Console.WriteLine(temp[0].SomeProperty); 
