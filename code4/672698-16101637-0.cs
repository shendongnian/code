    	public IList<string> GetProjectsFormCollection(Guid collectionId)
	{
		ICommonStructureService structureService = null;
		try
		{
			TfsTeamProjectCollection teamProjectCollection =
				_configurationServer.GetTeamProjectCollection(collectionId);
			teamProjectCollection.Authenticate();
			structureService =
				(ICommonStructureService)teamProjectCollection.GetService(typeof(ICommonStructureService));
		}
		catch (Exception e)
		{
			ApplicationLogger.Log(e);
		}
		var projectInfoList = new List<ProjectInfo>(structureService.ListAllProjects());
		IEnumerable<string> data = projectInfoList.Select(proj => proj.Name);
		List<string> list = data.ToList();
		return list;
	}
