    var scriptEngine = new ScriptEngine();
    var session = scriptEngine.CreateSession();
    session.AddReference("System");
    session.AddReference("System.Core");
    session.Execute(@"public int m() { return 6; }");
    int six = session.Execute<int>("m()");
