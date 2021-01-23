    IList<RepositoryLocalObject> rlos = structuregroup.GetItems(pageFilter);
    List<Page> pages = new List<Page>(rlos.Count);    
    foreach (RepositoryLocalObject o in rlos)
    {  
        Page p = (Page) o;
        bool isPublished = false;
        ICollection<PublishInfo> publishInfo = PublishEngine.GetPublishInfo(p);
        foreach (PublishInfo info in publishInfo)
        {
            if (info.Publication.Id.ItemId == p.Id.PublicationId)
            {
                isPublished = true;
            }
        }
        if(p != null && isPublished)
        {
            pages.Add(p);
        }
    }
