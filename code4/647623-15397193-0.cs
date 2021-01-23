    private List<string> GetConfRooms(string filter)
    {
        List<string> sRooms = new List<string>();
        DirectoryEntry deDomain = System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().GetDirectoryEntry();
        DirectorySearcher dsRooms = new DirectorySearcher(deDomain);
        dsRooms.Filter = string.Format("(&(&(&(mailNickname={0}*)(objectcategory=person)(objectclass=user)(msExchRecipientDisplayType=7))))", filter);
        dsRooms.PropertiesToLoad.Add("sn");
        dsRooms.PropertiesToLoad.Add("mail");
        foreach (SearchResult sr in dsRooms.FindAll())
        {
            sRooms.Add(sr.Properties["mail"][0].ToString());
        }
        return sRooms;
    }
