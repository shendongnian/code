    String userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    String dr = @"C:\Users\" + userName + @"\AppData\temp";
    DirectoryInfo dir = new DirectoryInfo(@dr);
    foreach (FileInfo file in dir.GetFiles())
    {
        try
        {
            file.Delete();
        }
        catch (IOException ex)
        {//Log ex.message
            continue;
        }
    }
    foreach (DirectoryInfo dire in dir.GetDirectories())
    {
        try
        {
            dire.Delete();
        }
        catch (IOException ex)
        { //Log ex.message
            continue;
        }
    }
    
    
