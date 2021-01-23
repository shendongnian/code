    var engine = Python.CreateEngine();
    dynamic scope = engine.CreateScope();
    Action<string> writeLine = msg => Console.WriteLine(msg);
    // or even
    //Action<string> writeLine = Console.WriteLine;
    scope.writeLine = writeLine;
    //engine.Execute("writeLine(msg='foo')", scope); // error
    engine.Execute("writeLine(obj='foo')", scope); // works
