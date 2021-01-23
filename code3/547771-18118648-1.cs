    string strName;
     Vimba sys = new Vimba ();
     CameraCollection cameras=null;
    
     try
     {
     sys.Startup ();
     cameras = sys.Cameras;
    
     Console.WriteLine( "Cameras found: " + cameras.Count );
     Console.WriteLine ();
    
     foreach (Camera camera in cameras)
     {
     try
     {
     strName = camera.Name;
     }
     catch ( VimbaException ve )
     {
     strName = ve.Message;
     }
     Console.WriteLine( "/// Camera Name: " + strName );
     }
     }
     finally
     {
     sys.Shutdown ();
     }
