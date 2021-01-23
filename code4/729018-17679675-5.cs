    public void OnItemSaving(object sender, EventArgs args)
    {
    	Item item = Event.ExtractParameter(args, 0) as Item;
    	if (item == null)
    		return;
    
    	item.Fields.ReadAll(); 
    	foreach (Field field in item.Fields)
    	{
    		if (!field.IsModified) //check if the field is modified
        		continue;
    
     		Log.Audit(string.Format("OnItemSaving - Item field {0} was modified at: {1}, by user: {2}", field.DisplayName, item.Statistics.Updated.ToString(CultureInfo.InvariantCulture), item.Statistics.UpdatedBy), this);
		}
	}
