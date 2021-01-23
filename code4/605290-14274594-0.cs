        public string GetLoggedUserName()
        {
            string rtn = string.Empty;
            
            if (CurrentContext.User != null)
            {
                if (CurrentContext.User.Identity.IsAuthenticated)
                {
                    var gp = CurrentContext.User as GenericPrincipal;
                    if (gp!=null)
                    {
                        //gp should be castable to WindowsIdentity                      
                        rtn = gp.Identity.Name;
                    }
                }
            }
            return rtn;
        }
