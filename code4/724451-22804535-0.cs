            ScriptEngine roslynEngine = new ScriptEngine();
            Roslyn.Scripting.Session session = roslynEngine.CreateSession();
            session.AddReference("System.Web");
            session.ImportNamespace("System");
            session.ImportNamespace("System.Web");
            var result = (session.Execute("1 + 1"));
