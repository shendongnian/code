    public override void OnPostLoad(PostLoadEvent @event)
    {
        base.OnPostLoad(@event);
        // the entity with <any> mapping 
        ConvertToNull(@event.Entity as MyAuditEntity); 
    }
    
    protected virtual void ConvertToNull(MyAuditEntity item)
    {
        if (item == null)
        {
            return;
        }
        try
        {
            // access some property to check that reference is not a PROXY
            var id = item.AnyEntity.ID;
        }
        catch
        {
            // replace proxy with null
            item.AnyEntity = null; 
        }
    }
