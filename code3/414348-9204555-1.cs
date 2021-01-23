    var engine = Python.CreateEngine();
    dynamic scope = engine.CreateScope();
    Action<string> writeLine = msg => Console.WriteLine(msg);
    scope.writeLine = writeLine;
    //engine.Execute("writeLine(msg='foo')", scope); // error
    engine.Execute("writeLine(obj='foo')", scope); // works
