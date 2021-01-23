    // Now, gets associated work items!
    Dictionary<int, WorkItem> dico = new Dictionary<int, WorkItem>();
    foreach (int changesetId in newChangesets)
    {
    	foreach (WorkItem zz in vcs.GetChangeset(changesetId).WorkItems)
    	{
    		this.AddWorkItemToDicRecursive(wis, dico, zz);
    	}
    }
    
    private void AddWorkItemToDicRecursive(WorkItemStore wis, Dictionary<int, WorkItem> dico, WorkItem workItem)
    {
    	if (!dico.ContainsKey(workItem.Id))
    	{
    		dico.Add(workItem.Id, workItem);
    
    		foreach (WorkItemLink associatedItem in workItem.WorkItemLinks)
    		{
    			this.AddWorkItemToDicRecursive(wis, dico, wis.GetWorkItem(associatedItem.TargetId));
    		}
    	}
    }
