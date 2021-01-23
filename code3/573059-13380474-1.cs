    internal void HookUpAutomaticHandlers()
    {
      ...
      object obj = TemplateControl._eventListCache[(object) this.GetType()];
      if (obj == null)
      {
    	lock (TemplateControl._lockObject)
    	{
    	  obj = TemplateControl._eventListCache[(object) this.GetType()];
    	  if (obj == null)
    	  {
    		IDictionary local_1_1 = (IDictionary) new ListDictionary();
    		this.GetDelegateInformation(local_1_1);
    		obj = local_1_1.Count != 0 ? (object) local_1_1 : TemplateControl._emptyEventSingleton;
    		TemplateControl._eventListCache[(object) this.GetType()] = obj;
    	  }
    	}
      }
      ...
