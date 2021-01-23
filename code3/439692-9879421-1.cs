    // initialize, maybe in a constructor
    Dictionary<string, Action> nameDelegateMapping = new Dictionary<string, Action>();
    // setup the delegates
    nameDelegateMapping.Add("Daily_Unload", reportDailyUnload);
    // ... add more methods here.
    
    // later
    string methodName = this.cboSelectReport.Text;
    Action action;
    if (nameDelegateMapping.TryGetValue(methodName, out action))
    {
      action();
    }
    else
    {
      // tell user the method does not exist.
    }
