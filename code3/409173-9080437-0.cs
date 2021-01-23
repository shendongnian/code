    public static dynamic RunIronPythonScript(string fileName)
    {
        var ipy = IronPython.Hosting.Python.CreateRuntime();
        try
        {
            dynamic test = ipy.ExecuteFile(fileName);
            return test;
        }
        catch (Exception e)
        {
            var engine = IronPython.Hosting.Python.GetEngine(ipy);
            ExceptionOperations eo = engine.GetService<ExceptionOperations>();
            string error = eo.FormatException(e);
            throw new Exception(error);
        }
    }
