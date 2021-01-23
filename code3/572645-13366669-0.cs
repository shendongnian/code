    public class Student_A
    {
    	public int Id{get;set;}
    	public string FirstName{get;set;}
    	public string LastName{get;set;}
    }
    
    public class Student_B
    {
    	public int Id{get;set;}
    	public string FirstName{get;set;}
    	public string MiddleName{get;set;}
    	public string LastName{get;set;}
    }
    
    void Main()
    {
    	List<Student_A> StudentAs = new List<Student_A>();
    	StudentAs.Add(new Student_A(){Id = 1, FirstName = "Jack", LastName = "Smith"});
    	StudentAs.Add(new Student_A(){Id = 3, FirstName = "Sarah", LastName = "Jane"});
    	StudentAs.Add(new Student_A(){Id = 7, FirstName = "Zack", LastName = "Hall"});
    	
    	List<Student_B> StudentBs = new List<Student_B>();
    	StudentBs.Add(new Student_B(){Id = 2, FirstName = "Jane", MiddleName = "T.", LastName = "Kelly"});
    	StudentBs.Add(new Student_B(){Id = 9, FirstName = "Rose", MiddleName = "Marie", LastName = "Tyler"});
    	StudentBs.Add(new Student_B(){Id = 4, FirstName = "Bobby", MiddleName = "Stephen", LastName = "Singer"});
    	
    	var result = StudentAs.Union((IEnumerable<Object>)StudentBs);
    	
    	result.Dump();
    }
