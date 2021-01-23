    public static class InstalledApplicationPaths
    {
    
       public static string GetInstalledApplicationPath( string shortName )
       {
          var path = GetInstalledApplicationPaths().SingleOrDefault( x => x?.ExectuableName.ToLower() == shortName.ToLower() )?.Path;
          return path;
       }
    
       public static IEnumerable<(string ExectuableName, string Path)?> GetInstalledApplicationPaths()
       {
          using ( RegistryKey key = Registry.LocalMachine.OpenSubKey( @"Software\Microsoft\Windows\CurrentVersion\App Paths" ) )
          {
             foreach ( var subkeyName in key.GetSubKeyNames() )
             {
                using ( RegistryKey subkey = key.OpenSubKey( subkeyName ) )
                {
                   yield return (subkeyName, subkey.GetValue( "" )?.ToString());
                }
             }
          }
       }
    
    }
