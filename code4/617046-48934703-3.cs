    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    public class AD
    {
        public AD()
        {
            ActiveDirectory = new DirectoryEntry("LDAP://" + 
        Environment.UserDomainName);
        }
    public DirectoryEntry ActiveDirectory { get; private set; }
    public ADbitLock GetBitLocker(string hostname)
        {
            var output = new StringBuilder();
            DirectorySearcher directorySearcher = new DirectorySearcher(ActiveDirectory);
            directorySearcher.Filter = "(&(ObjectCategory=computer)(cn=" + hostname + "))";
            
            var Result = directorySearcher.FindOne();
            var Rpath = Result.Path;
            var BTsearch = new DirectorySearcher(Rpath)
            {
                SearchRoot = Result.GetDirectoryEntry(), //without this line we get every entry in AD.
                Filter = "(&(objectClass=msFVE-RecoveryInformation))"
            };
            BTsearch.PropertiesToLoad.Add("msfve-recoveryguid");
            BTsearch.PropertiesToLoad.Add("msfve-recoverypassword");
            var GetAll = BTsearch.FindAll();
            var BT = new ADbitLock(hostname);
            foreach (SearchResult item in GetAll)
            {
                if (item.Properties.Contains("msfve-recoveryguid") && item.Properties.Contains("msfve-recoverypassword"))
                {
                    var pid = (byte[])item.Properties["msfve-recoveryguid"][0];
                    var rky = item.Properties["msfve-recoverypassword"][0].ToString();
                        BT.AddKey(pid, rky);
                    var lnth = BT.RecoveryKey.Count - 1;
                    System.Diagnostics.Debug.WriteLine("Added... " + BT.PasswordID[lnth] + " for: " + BT.RecoveryKey[lnth]);
                }
            }
            return BT;
            
        }
    }
    public class ADbitLock
    {
        public ADbitLock(string HostName)
        {
            SystemName = HostName;
            PasswordID = new List<string>();
            RecoveryKey = new List<string>();
        }
        public void AddKey(byte[] ID, string Key)
        {
            PasswordID.Add(ConvertID(ID));
            RecoveryKey.Add(Key);
        }
        private string ConvertID(byte[] id)
        {
            return
              id[3].ToString("X02") + id[2].ToString("X02")
            + id[1].ToString("X02") + id[0].ToString("X02") + "-"
            + id[5].ToString("X02") + id[4].ToString("X02") + "-"
            + id[7].ToString("X02") + id[6].ToString("X02") + "-"
            + id[8].ToString("X02") + id[9].ToString("X02") + "-"
            + id[10].ToString("X02") + id[11].ToString("X02")
            + id[12].ToString("X02") + id[13].ToString("X02")
            + id[14].ToString("X02") + id[15].ToString("X02")
                ;
        }
        public string SystemName { get; private set; }
        public List<string> PasswordID { get; private set; }
        public List<string> RecoveryKey { get; private set; }
    }
