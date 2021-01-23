    public static void HandleException(object a_s, UnhandledExceptionEventArgs a_args)
    {
        var _e = (Exception)a_args.ExceptionObject;
        Console.WriteLine(_e.GetType().ToString(), _e.Message, "default solution");
    }
    public void StarProcessWithinAppDomain(string fileName)
    {
        try
        {
            // New appdoamin / check exception isolation level 
            AppDomain sandBox = AppDomain.CreateDomain("sandBox");
            try
            {
                AppDomain.CurrentDomain.UnhandledException += HandleException;
                sandBox.ExecuteAssembly(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred (inner) within AppDomain, executing \"{0}\":" + "\n" + ex.Message, fileName);
            }
            finally
            {
                AppDomain.Unload(sandBox); // Destroy created appdomain and memory is released.
            }
        }
        catch (Exception ex)//Any exception that generate from executable can handle
        {
            Console.WriteLine("An error occurred within AppDomain, executing \"{0}\":" + "\n" + ex.Message, fileName);
        }
    }
