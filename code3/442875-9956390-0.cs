    private void addContentInCmbPhy() 
    {
    	List<string> match;
    	using (var  myDb = new DbClassesDataContext(dbPath))
    	{
    		match = (from phy in myDb.Physicians
    				select phy.Phy_FName).ToList();
    	}
    			
    
    	foreach(var phy in match){
    		cmbPhysicians.Items.Add(phy);
    	}
    }
