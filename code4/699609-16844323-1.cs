    var Data1Task = Task.Factory.StartNew(WebService1.Call);
    var Data2Task = Task.Factory.StartNew(WebService2.Call);
    var Data3Task = Task.Factory.StartNew(WebService3.Call);
    Data1Task.Wait();
    var Data1 = Data1Task.Result;
    Data2Task.Wait();
    var Data2 = Data2Task.Result;
    Data3Task.Wait();
    var Data3 = Data3Task.Result;
