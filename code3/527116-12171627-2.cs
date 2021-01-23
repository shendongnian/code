     SPSecurity.RunWithElevatedPrivileges(delegate()
     {
       using (SPSite site = new SPSite("http URL"))
        {
            using (SPWeb web = site.OpenWeb())
            {  
                web .AllowUnsafeUpdates = true;
                SPListItemCollection listitems = web.Lists["List name"].Items;
                SPListItem userItem = listitems.Add();
                userItem ["col 1"] = Data1;
                userItem ["col 2"] = Data2;
                userItem ["col 3"] = Data3;
                userItem ["col 4"] = Data4;
                userItem ["col 5"] = Data5;
                userItem.Update();               
                web .AllowUnsafeUpdates = false;
            }
        }
      });
       
