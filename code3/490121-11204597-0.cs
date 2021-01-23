    public static void runBatch( string path, int sleepTime = 3000 )
    {
       ProcessStartInfo psi = new ProcessStartInfo( path );
     
       psi.UseShellExecute = false;
    
       Process proc = new Process();
       proc.StartInfo = psi;
    
       proc.Start();
       Thread.Sleep( sleepTime );
    }
    
    
    main()
    {
        runBatch(Server.MapPath(".") + "\\execute.bat");
        runBatch(Server.MapPath(".") +"\\executeN.bat");
    ...
    }
