    IDictionary<string, object> options = new Dictionary<string, object>();
    options["Arguments"] = new [] {"C:\Program Files (x86)\IronPython 2.7\Lib", "bar"};
    
    var ipy = Python.CreateRuntime(options);
    dynamic Python_File = ipy.UseFile("test.py");
    
    Python_File.MethodCall("test");
