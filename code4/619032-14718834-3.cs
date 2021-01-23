    class Elevated_Rights
    {
    
        // Token Bool:
        private bool _level = false;
    
        #region Constructor:
    
        protected Elevated_Rights()
        {
             // Invoke Method On Creation:
             Elevate();
         }
    
         #endregion
    
         public void Elevate()
         {
             // Get Identity:
             WindowsIdentity user = WindowsIdentity.GetCurrent();
    
             // Set Principal
             WindowsPrincipal role = new WindowsPrincipal(user);
    
             #region Test Operating System for UAC:
    
             if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major < 6)
             {
                  // False:
                  _level = false;
             }
             #endregion
    
             else
             {
                  #region Test Identity Not Null:
    
                  if (user == null)
                  {
                        // False:
                        _level = false;
                  }
                  #endregion
    
                  else
                  {
                        #region Ensure Security Role:
    
                        if (!(role.IsInRole(WindowsBuiltInRole.Administrator)))
                        {
                            // False:
                            _level = false;
                        }
                        else
                        {
                            // True:
                            _level = true;
                        }
                        #endregion
                   }
              }
     } 
