    var oneAndTwo = new Implementation();
    var a = new UsingImplementation(oneAndTwo, oneAndTwo);
    // operates on the first param (which is the same as the second)
    a.DoSomeThingWithOne();
    // operates on the second param (which is the same as the first)
    a.DoSomeThingWithTwo();
