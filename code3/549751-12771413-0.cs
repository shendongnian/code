    public static bool isGlassEnabled{
        get {
            if (System.Environment.OSVersion.Version.Major >= 6) {
                 DwmIsCompositionEnabled( ref en );
                if (en > 0) {
                   return true;
                } else { return false; }
            } else { return false; }
       }
    }
