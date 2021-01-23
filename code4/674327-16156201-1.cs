    private string key;
    
    public string Key 
    {
       get { return key; }
       set 
       {
           if (key == value) return;
           // try data update 
           bool success = updateDB();
           if (success) key = value;  // only update if success
       }
    }
