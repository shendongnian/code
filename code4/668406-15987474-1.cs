    void Main()
    {
        List<UserMaster> users = new List<UserMaster>{
            new UserMaster{Name = "Bob",  Email = "bob@mail.ru",  Salary = 10},
            new UserMaster{Name = "Jack", Email = "jack@mail.ru", Salary = 20},
            new UserMaster{Name = "John", Email = "john@mail.ru", Salary = 40},
        };
    
        Mapper.CreateMap<UserMaster, UserMasterTemp>();
    
        List<UserMasterTemp> usersTemp = Mapper.Map<IEnumerable<UserMaster>,
    	                                            List<UserMasterTemp>>(users);
    
        usersTemp.ForEach(user => Console.WriteLine (user));
    }
    class UserMaster
    {
    	public string Name { get; set; }
    	public string Email { get; set; }
    	public decimal Salary { get; set; }
    }
    class UserMasterTemp
    {
    	public string Name { get; set; }
    	public string Email { get; set; }
    	public decimal Salary { get; set; }
    	
    	//formating for demo purposes
    	public override string ToString()
    	{
    		return string.Format("Name: {0}, Email: {1}, Salary: {2}", 
                                  Name, Email, Salary);
    	}
    }
