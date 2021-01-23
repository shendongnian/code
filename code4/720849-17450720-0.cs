    public void SaveValues()
        {
            // Expensive, to use reflection, especially if LOTS of objects are going to be used. 
            // You can use straight properties here if you want, this is just the lazy mans way.
    
            this.GetType().GetProperties().ToList().ForEach(tProp => { BackingStore[tProp.Name] = tProp.GetValue(this, null); Changes[tProp.Name] = ""; });
            HttpContext.Current.Session["SbackingStore"] = BackingStore;
    
    
            HasChanges = false;
    
        }
