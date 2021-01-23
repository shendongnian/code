    var t1 = new Task<int>( () => 1);
    var t2 = t1.ContinueWith(r => 1 + r.Result)
               .ContinueWith(r => 1 + r.Result);
    t1.Start();
    
    Console.Write(t1.Result); //1
    Console.Write(t2.Result); //3
