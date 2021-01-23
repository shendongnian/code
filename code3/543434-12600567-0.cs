    public static BCSMappedTable GetMappedTable(string p_ListName)
        {
            List<BCSDataBase> ConnexionList = BCSManagement.GetAllDataBases();
            bool found = false;
            foreach (BCSDataBase connexion in ConnexionList)
            {
                foreach (BCSMappedTable tabList in connexion.GetMappedTables())
                {
                    if (tabList.getListeName().Equals(p_ListName))
                    {
                        found = true;
                        return tabList;
                    }
                }
            }
            if (!found)
                return new BCSMappedTable();
        }
