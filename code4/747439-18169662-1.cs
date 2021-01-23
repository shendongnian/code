    public void UpdateLinks(EventViewModel form)
    {
        var selectedIds = form.Links.Select(r => r.ResourceTypeID).ToList();
        var assignedIds = form.Event.Links.Select(r => r.ResourceTypeID).ToList();
        foreach (var resource in form.Links
            .Where(r=> !assignedIds.Contain(r.ResourceTypeID)).ToArray())
        {
            resource.EventID = form.Event.ID;
            form.Event.Links.Add(resource);
        }
        foreach (var resource in form.Event.Links
            .Where(r=> !selectedIds.Contain(r.ResourceTypeID)).ToArray())
        {
            form.Event.Links.Remove(resource);
        }
    }
