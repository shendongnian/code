    TypedValue[] filterlist = new TypedValue[1];
    filterlist[0] = new TypedValue(0, "INSERT");
    SelectionFilter filter =  new SelectionFilter(filterlist);
    PromptSelectionResult selRes =  ed.SelectAll(filter);
            
    if (selRes.Value.Count != 0)
    {
        SelectionSet set = selRes.Value;
    
        foreach (ObjectId id in set.GetObjectIds())
        {
            BlockReference oEnt = (BlockReference)tr.GetObject(id, OpenMode.ForWrite);
            //do something with oEnt..;
        }
    
    }
