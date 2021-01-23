    static void main()
    {
    
         string exchangeServerVersion = string.Empty;
         exchangeServerVersion =getExchangeServerVersion();
         if (exchangeServerVersion.Contains("Version 6"))
                {
                    users.GetExchange2003UserList();
                    GetADGroupList();
                }
                else if (exchangeServerVersion.Contains("Version 8"))
                {
                    users.GetExchange2007UserList();
                    GetADGroupList();
                }
                else if (exchangeServerVersion.Contains("Version 14"))
                {
                    users.GetExchange2010UserList();
                    GetADGroupList();
                }
    }
