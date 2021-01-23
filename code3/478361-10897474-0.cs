    public void DoSiteOperationActions(Action<SiteOperation> toDo)
    {
            foreach (Sites site in _sitesManagement.GetAll())
            {
               SiteOperation mySiteOperation = new SiteOperation(site);
               toDo(mySiteOperation);
            }
    }
