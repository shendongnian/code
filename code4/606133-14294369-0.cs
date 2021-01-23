    public class Student 
    {
    	public Student (int age, string name)
    	{
    		Age = age;
    		Name = name;
    	}
    	
    	private string Name { get;  set; }
    
    	public int Age { get; set; }
    
    	public override string ToString ()
    	{
    		return string.Format ("[Student: Age={0}, Name={1}]", Age, Name);
    	}
    }
