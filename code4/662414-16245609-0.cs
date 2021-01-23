     private void ddlBackupselectuser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lbBackupprinters.Items.Clear();
            string selecteduser = ddlBackupselectuser.Text;
            string computer = ddlBackupselectcomp.Text;
            string sid;
            lblBackuppwd.Visible = true;
            txtBackuppwd.Visible = true;
            cboBackuppwdshow.Visible = true;
            //BEGIN GRAB PRINTERS FROM REGISTRY
            try
            {
                NTAccount ntuser = new NTAccount(selecteduser);
                SecurityIdentifier sID = (SecurityIdentifier)ntuser.Translate(typeof(SecurityIdentifier));
                lblBackupStatus.Text = sID.ToString();
                sid = sID.ToString();
            }
            catch (IdentityNotMappedException)
                {
                    lblBackupStatus.Text = "ERROR "+ ddlBackupselectuser.Text.ToString() + " contains no profile information";
                    lbBackupprinters.Items.Add("No Printers Found");
                return;
                }
            
            
                     ConnectionOptions co = new ConnectionOptions();
                     co.EnablePrivileges = true;
                     co.Impersonation = ImpersonationLevel.Impersonate;
                   
                     System.Net.IPHostEntry h = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                     string IPAddress = h.AddressList.GetValue(0).ToString();
                     string lm = System.Net.Dns.GetHostName().ToString();
                    try
                     {
                         
                         ManagementScope myScope = new ManagementScope("\\\\" + computer + "\\root\\default", co);
                         ManagementPath mypath = new ManagementPath("StdRegProv");
                         ManagementClass wmiRegistry = new ManagementClass(myScope, mypath, null);
 
                        const uint HKEY_LOCAL_MACHINE = unchecked((uint)0x80000002);
                         //ManagementClass wmiRegistry = new ManagementClass("root/default",
                         //"StdRegProv",null);
						 
                         string keyPath = @"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Providers\\Client Side Rendering Print Provider\\" + sid + "\\Printers\\Connections";
                         object[] methodArgs = new object[] { HKEY_LOCAL_MACHINE, keyPath, null };
                         uint returnValue = (uint)wmiRegistry.InvokeMethod("EnumKey", methodArgs);
                         
                         if (null != methodArgs[2])
                         {
                             string[] subKeys = methodArgs[2] as String[];
                             if (subKeys == null)
                             {
                                 lbBackupprinters.Items.Add("No Printers Found");
                                 return;
                             }
                             ManagementBaseObject inParam = wmiRegistry.GetMethodParameters("GetStringValue");
                             inParam["hDefKey"] = HKEY_LOCAL_MACHINE;
                             string keyName = "";
                             foreach (string subKey in subKeys)
                             {
                                 //Display application name
                                 keyPath = @"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Print\\Providers\\Client Side Rendering Print Provider\\" + sid + "\\Printers\\Connections" + subKey;
                                 keyName = "DisplayName";
                                 inParam["sSubKeyName"] = keyPath;
                                 inParam["sValueName"] = keyName;
                                 ManagementBaseObject outParam = wmiRegistry.InvokeMethod("GetStringValue", inParam, null);
                                     lbBackupprinters.Items.Add(subKey);
                                     
                             }
                         }
                         else
                         {
                             lbBackupprinters.Items.Add("No Printers Found");                             
                         }
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show("Error: " + ex.Message);
                    }
