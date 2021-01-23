    TypedValue[] filterlist = new TypedValue[2];
    filterlist[0] = new TypedValue(0, "INSERT");
    SelectionFilter filter =  new SelectionFilter(filterlist);
    PromptSelectionOptions opts =  new PromptSelectionOptions();
    
    opts.MessageForAdding = "Select entities: ";
    PromptSelectionResult selRes =  ed.GetSelection(opts, filter);
            
    if (selRes.Status != PromptStatus.OK)
    {
        ed.WriteMessage("\nNo ABC block references selected");
        return;
    }
            
    if (selRes.Value.Count != 0)
    {
        SelectionSet set = selRes.Value;
    
        foreach (ObjectId id in set.GetObjectIds())
        {
            BlockReference oEnt = (BlockReference)tr.GetObject(id, OpenMode.ForWrite);
            oEnt.Erase();
        }
    
    }
