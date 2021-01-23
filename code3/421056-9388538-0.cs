        SPWeb mySite = SPContext.Current.Web;
        
        SPListItemCollection listItems = mySite.Lists["myList"].Items;
        
        SPListItem item = listItems.Add();
        
        string[] UsersSeperated = pplEditor.CommaSeparatedAccounts.Split(',');
        
        SPFieldUserValueCollection UserCollection = new SPFieldUserValueCollection();
        
        foreach (string UserSeperated in UsersSeperated)
        
           {
    
        mySite.EnsureUser(UserSeperated);
    
        SPUser User = mySite.SiteUsers[UserSeperated];
    
        SPFieldUserValue UserName = new SPFieldUserValue(mySite, User.ID, User.LoginName);
    
        UserCollection.Add(UserName);
    
       }
    
    item["people"] = UserCollection;
    
    item.Update();
