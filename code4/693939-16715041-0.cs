    using System.Security.Principal;
    using System.Management;
    private void GetLocalUserAccounts()
    {
         SelectQuery query = new SelectQuery("Win32_UserProfile");
         ManagementObjectsSearcher searcher = new ManagementObjectSearcher(query);
         foreach (ManagementObject sid in searcher.Get())
         {
              MessageBox.Show(new SecurityIdentifier(sid["SID"].ToString()).Translate(typeof(NTAccount)).ToString());
         }
    }
