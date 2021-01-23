    public bool IsFirstCheckIn(SPListItem item)
    {
        // Item not null!
        if (item != null)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                // Open privileged Site
                using (SPSite pSite = new SPSite(site.ID))
                {
                    // Open privileged Web
                    using (SPWeb pWeb = pSite.OpenWeb(web.ID))
                    {
                        // Create privileged SharePoint-Objects
                        SPList pList = GetList(pWeb, list.ID);
                        SPListItem pItem = GetListItem(pList, item.UniqueId);
    
                        // Check the Item
                        if (pItem == null)
                        {
                            // Can't access
                            return true;
                        }
                        else if (pItem.File != null && pItem.File.CheckedOutByUser != null)
                        {
                            // If the Item's File and checked out User is set, check if checked out date is equal creation date
                            return (pItem.File.CheckedOutDate.ToLocalTime() == pItem.File.TimeCreated.ToLocalTime());
                        }
                    }
                }            
            });    
        }
        
        return false;
    }
