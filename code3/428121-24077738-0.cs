    try {
    Settings.Default.Reload();
    } 
    catch ( ConfigurationErrorsException ex ) 
    { 
      string filename = ( (ConfigurationErrorsException)ex.InnerException ).Filename;
    if ( MessageBox.Show( "<ProgramName> has detected that your" + 
                          " user settings file has become corrupted. " +
                          "This may be due to a crash or improper exiting" + 
                          " of the program. <ProgramName> must reset your " +
                          "user settings in order to continue.\n\nClick" + 
                          " Yes to reset your user settings and continue.\n\n" +
                          "Click No if you wish to attempt manual repair" + 
                          " or to rescue information before proceeding.",
                          "Corrupt user settings", 
                          MessageBoxButton.YesNo, 
                          MessageBoxImage.Error ) == MessageBoxResult.Yes ) {
        File.Delete( filename );
        Settings.Default.Reload();
        // you could optionally restart the app instead
    } else
        Process.GetCurrentProcess().Kill();
        // avoid the inevitable crash
    }
