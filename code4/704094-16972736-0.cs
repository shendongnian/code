        string ExecutePythonScript(string path, string text)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            ICollection<string> Paths = engine.GetSearchPaths();
            Paths.Add(".");
            Paths.Add("D:\\DevTools\\IronPython 2.7\\Lib");
            Paths.Add("D:\\DevTools\\IronPython 2.7\\DLLs");
            Paths.Add("D:\\DevTools\\IronPython 2.7");
            Paths.Add("D:\\DevTools\\IronPython 2.7\\lib\\site-packages");
            engine.SetSearchPaths(Paths);
            scope.SetVariable("text", text);
            engine.ExecuteFile(path, scope);
            (...)
