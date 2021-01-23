    public partial class Person 
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public Project Project { get; set; }
    	public List<Person> Friends { get; set; }
    }
    
    public partial class Project 
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }	
    
    select 
    	1 as [Id]
    	, 'NitinJs' as [Name]
    	, 5 as [Project.Id]
    	, 'Model Binding' as [Project.Name]
    	, 2 as [Friends[0]].Id]
    	, 'John' as [Friends[0]].Name]
    	, 3 as [Friends[1]].Id]
    	, 'Jane' as [Friends[1]].Name]	
	
