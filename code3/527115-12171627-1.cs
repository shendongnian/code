     SPSecurity.RunWithElevatedPrivileges(delegate()
     {
       using (SPSite site = new SPSite("http URL"))
        {
            using (SPWeb web = site.OpenWeb())
            {  
                web .AllowUnsafeUpdates = true;
                SPList list = web.Lists["List name"];
                UserItem = list.Items.Add();
                UserItem["col 1"] = Data1;
                UserItem["col 2"] = Data2;
                UserItem["col 3"] = Data3;
                UserItem["col 4"] = Data4;
                UserItem["col 5"] = Data5;
                UserItem.Update();
                list.Update();
                web .AllowUnsafeUpdates = false;
            }
        }
      });
       
