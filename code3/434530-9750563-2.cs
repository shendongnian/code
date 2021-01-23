    class ProjectDTO
    {
    	public string Name { get; set; }
    	
    	public static Expression<Func<Project, ProjectDTO>> ToDTO = (e) => new ProjectDTO
    	{
    		Name = e.Name
    	};
    	
    	public ProjectDTO() {}
    	
    	public ProjectDTO(Project project)
    	{
    		Name = project.Name;
    	}
    }
    
    void Main()
    {
    	Projects.Select(p => p.Name).Dump();
    	Projects.Select(ProjectDTO.ToDTO).Dump();
    	Projects.Select(p => new ProjectDTO(p)).Dump();
    }
