    ...
    foreach (var item in resourceList)
    {
        if(!string.IsNullOrEmpty(item.Value))	
    		window.Resources.Add(item.Key, item.Value);
    	else
    		window.Resources.Add(item.Key, item.Key);
    }
    ...
