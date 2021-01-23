    private static Version TargetedVersion = new Version(8, 0);
    public static bool IsTargetedVersion 
    {
       get
         {
           return Environment.OSVersion.Version >= TargetedVersion;
         }
     }
