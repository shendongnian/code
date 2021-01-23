    public class ReportSimple
    {
        public Guid ReportId { get; set; }
    	public int Project { get; set; }
        public int Location { get; set; } 
        public int Department { get; set; }
        public string Person { get; set; }
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public double RoundTrip { get; set; }
        public bool IsBillable { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] TimeUpdated { get; set; }
    	
    	public ReportSimple(Project project, Person person, StatusCode statusCode)
    	{
    	    Project = project.ProjectId;
    		Location = project.Location.LocationId;
    		Department = project.Department.DepartmentId;
    		Person = person.Email;
    		StatusCode = statusCode.StatusId;
    	}
    }
