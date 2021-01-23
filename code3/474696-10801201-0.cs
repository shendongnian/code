	Func<Project, Project, Project> mergeFunc = (p1,p2) => new Project
		{
			ProjectId = p1.ProjectId,
			ProjectName = p1.ProjectName == null ? p2.ProjectName : p1.ProjectName,
			Customer = p1.Customer == null ? p2.Customer : p1.Customer,
			Address = p1.Address == null ? p2.Address : p1.Address    
		};
	
	var output = lst1.Concat(lst2).Concat(lst3)
                     .GroupBy(x => x.ProjectId, (k, g) => g.Aggregate(mergeFunc)); 
