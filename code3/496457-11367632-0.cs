    string employeeIdToRemove = "1337";
    Guid siteGuid = SPContext.Current.Site.ID;
    
    SPSecurity.RunWithElevatedPermissions(delegate
    {
       using (SPSite mySite = new SPSite(siteGuid))
       {
          SPListItemCollection listItems = mySite.Lists["SuperSecretList"].Items;
          int itemCount = listItems.Count;
    
          for (int k=0; k<itemCount; k++)
          {
             SPListItem item = listItems[k];
    
             if (employeeIdToRemove.Equals(item["Employee"].ToString()))
             {
                 listItems.Delete(k);
             }
          }
       }
    });
