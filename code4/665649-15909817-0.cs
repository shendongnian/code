	int[] ids = new int[10];
	List<Project> projects = new List<Project>();
	
	var projectsDictionary = projects.ToDictionary(proj=> proj.Id, proj => proj);
	
	var orderedProjects = ids.Select(id => projectsDictionary[id]);
