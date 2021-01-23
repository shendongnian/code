    try
    {
        Process.Start("engine.exe", "/load /config debug");
        Application.Exit();    
    }
    catch(FileNotFoundException e)
    {
       MessageBox.Show(e.Message);
    }
