    Task<Dictionary<string,string>> GetDamaged()
    {
        return Task.Factory.StartNew(() => {
    		Dictionary <string, string> e = new Dictionary<string, string>();
    
    		foreach(Building i in buildingArray)
    		{
    			if(Convert.ToInt32(i.efficiency) < 100)
    			{
    				e.Add(i.buildingID, i.buildingName);
    			}
    		}
    		
    		return e;
    	}
    }
