    ScriptEngine engine = null;
    engine = Ruby.CreateEngine(x => { x.ExceptionDetail = true; });			
    
    ScriptSource sc = engine.CreateScriptSourceFromFile("MainForm.rb");
    ErrorListener errLis = new MyErrorListener();
    sc.Compile(errLis);
    
    try
    {
    	dynamic d = sc.Execute();
    }
    catch (MissingMethodException e)
    {
    	Console.WriteLine("Syntax error!");
    }
