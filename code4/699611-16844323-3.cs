    var fooTask = Task.Factory.StartNew(Foo);
    var barTask = Task.Factory.StartNew(Bar);
    var bazTask = Task.Factory.StartNew(Baz);
    fooTask.Wait();
    var fooResult = fooTask.Result;
    barTask.Wait();
    var barResult = barTask.Result;
    bazTask.Wait();
    var bazResult = bazTask.Result;
