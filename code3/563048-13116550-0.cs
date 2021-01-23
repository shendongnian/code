    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // you need to also take into account that someone could get to your
            // page without having a Windows account.... check for NULL !
            if (System.Security.Principal.WindowsIdentity == null ||
                System.Security.Principal.WindowsIdentity.GetCurrent() == null)
            {
                return;  // possibly return a message or something....
            }
            String username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            // if the user name returned is null or empty -> abort
            if(string.IsNullOrEmpty(username))
            {
               return;
            }
            username = username.Substring(3);
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, "dc");
            
            UserPrincipal user = UserPrincipal.FindByIdentity(pc, username);
    
            // finding the user of course can also fail - check for NULL !!
            if (user != null)
            {
                string NTDisplayName = user.DisplayName;
                //String NTUser = user.SamAccountName;
                lblntuser.Text = NTDisplayName;
            }
         }
         catch (Exception Ex)
         {
            lblntuser.Text = Ex.Message;
            System.Diagnostics.Debug.Write(Ex.Message);
         }
     }
