	List<Project> lst1; List<Project> lst2; List<Project> lst3;
	lst1 = new List<Project> 
		{
			new Project { ProjectId = 1, ProjectName = "P1" },
			new Project { ProjectId = 2, ProjectName = "P2" },
			new Project { ProjectId = 3, ProjectName = "P3" }
		};
	lst2 = new List<Project>
		{
			new Project { ProjectId = 1, Customer = "Cust1"},
			new Project { ProjectId = 2, Customer = "Cust2"},
			new Project { ProjectId = 3, Customer = "Cust3"}
		};
	lst3 = new List<Project>
		{
			new Project { ProjectId = 1, Address = "Add1"},
			new Project { ProjectId = 2, Address = "Add2"},
			new Project { ProjectId = 3, Address = "Add3"}
		};
		
	Func<Project, Project, Project> mergeFunc = (p1,p2) => new Project
		{
			ProjectId = p1.ProjectId,
			ProjectName = p1.ProjectName == null ? p2.ProjectName : p1.ProjectName,
			Customer = p1.Customer == null ? p2.Customer : p1.Customer,
			Address = p1.Address == null ? p2.Address : p1.Address    
		};
	
	var output = lst1
		.Concat(lst2)
		.Concat(lst3)
		.GroupBy(x => x.ProjectId, (k, g) => g.Aggregate(mergeFunc));
	
	IEnumerable<bool> assertedCollection = output.Select((x, i) => 
		x.ProjectId == (i + 1) 
		&& x.ProjectName == "P" + (i+1) 
		&& x.Customer == "Cust" + (i+1) 
		&& x.Address == "Add" + (i+1));
		
	Debug.Assert(output.Count() == 3);	
	Debug.Assert(assertedCollection.All(x => x == true));
