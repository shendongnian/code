    public static BCSMappedTable GetMappedTable(string p_ListName)
    {
        List<BCSDataBase> ConnexionList = BCSManagement.GetAllDataBases();
        foreach (BCSDataBase connexion in ConnexionList)
        {
            foreach (BCSMappedTable tabList in connexion.GetMappedTables())
            {
                if (tabList.getListeName().Equals(p_ListName))
                {
                    return tabList;
                }
            }
        }
        // this code won't be executed if the item was found before...
        return new BCSMappedTable();
    }
