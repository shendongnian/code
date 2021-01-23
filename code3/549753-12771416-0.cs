    public static bool isGlassEnabled
    {
        get 
        {
             if (System.Environment.OSVersion.Version.Major >= 6) 
             {
                 Int32 en;   // or whatever type exactly needed
                 DwmIsCompositionEnabled( ref en );
                 if (en > 0) 
                    return true;                
             }
             return false; 
        }
    }
