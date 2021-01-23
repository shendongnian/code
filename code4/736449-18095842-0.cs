    private static void Main (string [] args)
    {
    Application.EnableVisualStyles ();
    Application.SetCompatibleTextRenderingDefault (false);
    
                 Fm1 MainForm = new MainForm ();
                 Application.Run (fm1);
    
                 if (fm1.ToRestart)
                     Application.Restart ();
             }
