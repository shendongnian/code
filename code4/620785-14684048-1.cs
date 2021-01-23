    IEnumerable<string> GetPropertInfos(object o, string parent=null)
    {
    	Type t = o.GetType();  
    	PropertyInfo[] props = t.GetProperties(BindingFlags.Public|BindingFlags.Instance);
    	foreach (PropertyInfo prp in props)  
    	{  
    		if(prp.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary")
    		{
                // fix me: you have to pass parent + "." + t.Name instead of t.Name if parent != null
    			foreach(var info in GetPropertInfos(prp.GetValue(o), t.Name))
    				yield return info; 
    		}
    		else
    		{    
    			var value = prp.GetValue(o);   
    			var stringValue = (value != null) ? value.ToString() : "";
    			var info = t.Name + "." + prp.Name + ": " + stringValue;
    			if (String.IsNullOrWhiteSpace(parent))
    				yield return info; 
    			else
    				yield return parent + "." + info; 
    		}
    	}
    }
