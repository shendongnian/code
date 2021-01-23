    //untested pseudocode - hope this points you in the right direction
    SPList lookupItems = ... // add code here
    SPList list = ... // add code here
    string lookupFieldName = "LookupValue"; // change to the appropriate value
    foreach(SPListItem item in list.Items)
    { 
        string value = (string)item[lookupFieldName];
        if(value.Contains("#")) // value containing hash is most likely a lookup value already
        {
             // use SPFieldLookupValue to get actual value
             SPFieldLookupValue currentValue = new SPFieldLookupValue(value);
             value = currentValue.LookupValue;
        }
        
        // Get the list item (you will need this to find out its id value)
        SPListItem lookupItem = GetLookupListItem(lookupList, value);
        if(lookupItem == null)
        {
            //If it doesn't exist, create it
            lookupItem = AddNewLookupItem(lookupList, value);
            SPFieldLookupValue lookupValue = new      SPFieldLookupValue(lookupItem.ID,value));
            item["LookupValue"] = lookupValue.ToString();
            item.Update();
        }
    }
    SPListItem GetLookupListItem(SPList lookupList, string value)
    {
        // iterate through list to find item
        // use a list query if the list is too big for this to perform well (see here: http://msdn.microsoft.com/en-us/library/ie/ms456030.aspx)
        foreach(SPListItem item in lookupList)
        {
            string itemValue = (string)item[0]; // assuming lookup list has one field of type string containing lookup value
            if(value == itemValue)
            {
                return item;
            }
        }
        return null;
    }
    SPListItem AddLookupListItem(SPList list, string value)
    {
        SPListItem newItem = list.Add();
        newItem[0] = value;// assuming lookup list has one field of type string containing lookup value
        newItem.Update();
    }
    
