    public MyViewModel // model that is bound to the view
    {
    	private UserRepository _userRepo;
    	public EmployeeDto ActiveUser {get;set;}
    	
    	public MyViewModel()
    	{
    		_userRepo = new UserRepository();
    		LoadActiveUser();
    	}
    	
    	private void LoadActiveUser()
    	{
    		var userId = (int)HttpContext.Current.Session["activeUser"] ?? 0;
    		if(userId > 0)
    		{
    			ActiveUser = _userRepo.GetEmployee(userId);
    		}
    	}
    	
    }
    
    public UserRepository
    {
    	private SomeEntityGennedClass2 _myDal1;
    	private SomeEntityGennedClass2 _myDal2; // maybe you need to make some other data layer call in order to fill this object out
    	
    	public UserRepository()
    	{
    		_myDal1 = new SomeEntityGennedClass1();
    		_myDal2 = new SomeEntityGennedClass2(); 
    	}
    	
    	public EmployeeDto GetEmployee(int id)
    	{
    		var empDto = new EmployeeDto();
    		// get employee
    		var dalEmpResult = _myDal.FirstOrDefault(e => e.EmployeeId == id);
    		empDto.FirstName = dalResult.FName;
    		empDto.LastName = dalResult.LName;
    		empDto.Id = dalResult.EmployeeId;
    		
    		// get employee department info
    		var dalDeptResult = _myDal2.FirstOrDefault(d => e.DepartmentId == dalEmpResult.DeptartmentId);
    		empDto.DepartmentName = dalDeptResult.Name;
    		
    		return empDto;
    	}
    }
    
    // client friendly employee object
    [DataContract(Name="Employee")]
    public class EmployeeDto
    {
    	public int Id {get; internal set;}
    	
        [DataMember(Name="fname")]
    	[DisplayName("Employee First Name:")]
    	public string FirstName {get;set;}
    	
        [DataMember(Name="lname")]
    	[DisplayName("Employee Last Name:")]
    	public string LastName {get;set;}	
    	
    	public int DeptId {get;set;}
    	
        [DataMember(Name="dept")]
    	[DisplayName("Works at:")]
    	public string DepartmentName {get;set;}
    }
