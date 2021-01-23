    void Main()
    {
    	var allTechs = GetAllUsers();	
    	var freeTechsList = 
    	        //Start the Linq query by selecting all the available techs.
    			//Since GetAllUsers returns a DataTable, we use AsEnumerable
    			//to convert the DataTable to a queryable object
                from tech in allTechs.AsEnumerable()
    			//Now we add a where clause to the Linq query.  Essentially 
    			//what this clause does is just remove every tech that is in
    			//the assigned techs list (which is returned by GetAllAssignedUserToTask)
    			where 
    			!(
    				//This is our subquery; all this does is give us a list of Guids
    				//that identifies techs that are assigned.  Again, GetAllAssignedUserToTask
    				//returns a DataTable, so we use AsEnumerable to make it queryable with Linq
    				from assigned in GetAllAssignedUserToTask(allTechs).AsEnumerable()
    				select assigned.Field<Guid>("TechGUID")
    			//The above subquery has returned us a list of assigned techs, so we check if 
    			//the current tech we're looking at from GetAllUsers is in that list using 
    			//the Contains method.  Contains will tell us whether the current tech is in the 
    			//list of assigned techs.  Since we negate the result above (using !), that means
    			//that if the tech is in this list, he will not be included in the final result.
    			).Contains(tech.Field<Guid>("TechGUID"))
    			//Finally, we return the selected techs that have been filtered by our where clause
    			select tech; 
    		
        //Dump is basically just LinqPad's version of print so we can see the result.			
    	freeTechsList.Dump();
    }
    
    // Define other methods and classes here
    DataTable GetAllUsers()
    {
    	//create a datatable
    	var dt = new DataTable();
    	dt.Columns.Add(new DataColumn() {DataType = typeof(Guid), ColumnName = "TechGUID"});
    	dt.Columns.Add(new DataColumn() {DataType = typeof(String), ColumnName = "Name"});
    
    	//add some data
    	DataRow bob = dt.NewRow();
    	bob["Name"] = "Bob";
    	bob["TechGUID"] = Guid.NewGuid();
    	dt.Rows.Add(bob);
    	
    	DataRow phil = dt.NewRow();
    	phil["Name"] = "Phil";
    	phil["TechGUID"] = Guid.NewGuid();	
    	dt.Rows.Add(phil);
    	
    	DataRow joe = dt.NewRow();
    	joe["Name"] = "Joe";
    	joe["TechGUID"] = Guid.NewGuid();	
    	dt.Rows.Add(joe);
    	
    	return dt;
    	
    }
    
    DataTable GetAllAssignedUserToTask(DataTable allUsers)
    {
        //simulate Joe as our only assigned Tech
    	return allUsers.AsEnumerable()
    	               .Where(tech => tech.Field<String>("Name") == "Joe")
    				   .CopyToDataTable();
    }
