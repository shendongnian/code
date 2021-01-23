    var fooTask = Task.Factory.StartNew(Foo);
    fooTask.Wait();
    var fooResult = fooTask.Result;
    
    var barTask = Task.Factory.StartNew(Bar);
    barTask.Wait();
    var barResult = barTask.Result;
    
    var bazTask = Task.Factory.StartNew(Baz);
    bazTask.Wait();
    var bazResult = bazTask.Result;
