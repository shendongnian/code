        public string GetLoggedUserName()
        {
            string rtn = string.Empty;
            
            if (CurrentContext.User != null)
            {
                if (CurrentContext.User.Identity.IsAuthenticated)
                {
                    var gp = CurrentContext.User as WindowsIdentity;
                    if (gp!=null)
                    {                
                        rtn = gp.Identity.Name;
                    }
                }
            }
            return rtn;
        }
