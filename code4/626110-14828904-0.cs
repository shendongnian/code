    public class GetQuestions
    {
    	public List<Student> Questions { get; set; }
    }
    
    public class Student
    {
    	public string Code { get; set; }
    	public string Questions { get; set; }
    }
    void Main()
    {
    	var gq = new GetQuestions
    	{
    		Questions = new List<Student>
    		{
    			new Student {Code = "s1", Questions = "Q1,Q2"},
    			new Student {Code = "s2", Questions = "Q1,Q2,Q3"},
    			new Student {Code = "s3", Questions = "Q1,Q2,Q4"},
    			new Student {Code = "s4", Questions = "Q1,Q2,Q5"},
    		}
    	};
    	
        //Using Newtonsoft.json. Dump is an extension method of [Linqpad][4]
    	JsonConvert.SerializeObject(gq).Dump();
    }
