    using System.DirectoryServices;
    using System.Collections;
    using System.Runtime.InteropServices;
    [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
    static extern bool ConvertSidToStringSid(IntPtr pSid, out string strSid);
 
    private static string GetTextualSID(DirectoryEntry objGroup)
    {
        string sSID = string.Empty;
        byte[] SID = objGroup.Properties["objectSID"].Value as byte[];
        IntPtr sidPtr = Marshal.AllocHGlobal(SID.Length);
        sSID = "";
        System.Runtime.InteropServices.Marshal.Copy(SID, 0, sidPtr, SID.Length);
        ConvertSidToStringSid((IntPtr)sidPtr, out sSID);
        System.Runtime.InteropServices.Marshal.FreeHGlobal(sidPtr);
        return sSID; 
    }
    public static List<string> GetLocalAdministratorsNames()
    {
        List<string> admins = new List<string>();
        DirectoryEntry localMachine = new DirectoryEntry("WinNT://" + Environment.MachineName);
        string adminsSID = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null).ToString();
        string localizedAdmin = new System.Security.Principal.SecurityIdentifier(adminsSID).Translate(typeof(System.Security.Principal.NTAccount)).ToString();
        localizedAdmin = localizedAdmin.Replace(@"BUILTIN\", "");
        DirectoryEntry admGroup = localMachine.Children.Find(localizedAdmin, "group");
        object adminmembers = admGroup.Invoke("members", null);
        DirectoryEntry userGroup = localMachine.Children.Find("users", "group");
        object usermembers = userGroup.Invoke("members", null);
        //Retrieve each user name.
        foreach (object groupMember in (IEnumerable)adminmembers)
        {
            DirectoryEntry member = new DirectoryEntry(groupMember);
            string sidAsText = GetTextualSID(member);
            admins.Add(member.Name);            
        }
        return admins;
    }
