     private static void Main(string[] args) {
                ScriptEngine engine = Python.CreateEngine();
    
                string script = "x = GetMyString('value')";
    
                Foo foo = new Foo();
    
                ScriptSource scriptSource = engine.CreateScriptSourceFromString(script);
    
                ScriptScope scope = engine.CreateScope();
                scope.SetVariable("GetMyString", new Func<string, string>(foo.GetMyString));
    
                scriptSource.Execute(scope);
    
                string output = scope.GetVariable<string>("x");
                Console.WriteLine(output);
            }
