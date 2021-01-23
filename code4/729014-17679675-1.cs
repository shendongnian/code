    public class LogFieldChanges
    {
        public void Process(SaveArgs args)
    	{
    		foreach (var saveItem in args.Items) //loop through item(s) being saved
    		{
    			var item = Sitecore.Context.ContentDatabase.GetItem(saveItem.ID, saveItem.Language, saveItem.Version); //get the actual item being saved
    			if (item == null)
    				continue;
    
    			foreach (var saveField in saveItem.Fields) //loop through the fields being saved
    			{
    				var field = item.Fields[saveField.ID]; //retrieve the Field from the actual item
    				var isModified = saveField.OriginalValue != saveField.Value; //determine if the field has been modified, we only want to log modified fields
    				if (field == null || !isModified)
    					continue;
    
    				Log.Audit(string.Format("SaveUI - Item field {0} was modified at: {1}, by user: {2}", field.DisplayName, item.Statistics.Updated.ToString(CultureInfo.InvariantCulture), item.Statistics.UpdatedBy), this);
    			}
    		}
    	}
   	}
