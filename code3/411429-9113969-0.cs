    try
    {
        using (Process exeProcess = Process.Start(startInfo))
        {
            exeProcess.WaitForExit();
        }
    }
    catch(Exception ex)
    {
         Console.Writeline(ex.ToString());
         Console.ReadKey();
    }
