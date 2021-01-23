    public void InitializeStatusList(DropDownList list)
    {    
        Func<Entry,bool> predicate=entry=>entry is EntryStatus1 || entry is EntryStatus2;
        CommonInitializeStatusList(list, predicate);
    }
    public void CommonInitializeStatusList(DropDownList list, Func<Entry,bool> predicate)
    {                                 
        var dictionaryEntries = GetEntriesFromDatabase();    
        list.DataSource = dictionaryEntries.Where(predicate);
        list.DataBind();
                
    }
