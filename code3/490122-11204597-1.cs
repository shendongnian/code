    public static void runBatch( string path )
    {
       ProcessStartInfo psi = new ProcessStartInfo( path );
    
       psi.UseShellExecute = false;
    
       Process proc = new Process();
       proc.StartInfo = psi;
    
       proc.Start();
       proc.WaitForExit();
    }
