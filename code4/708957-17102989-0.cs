    void Main()
    {
        Class myClassObj = new Class();
    	myClassObj.Variable = 1;
    	myClassObj.ListVariable = new List<AnotherClass>();
    	myClassObj.ListVariable.Add(new AnotherClass{ Variable="some", IntVariable=2 });
    
        Console.WriteLine(myClassObj.ToString());
    }
    public class Class
    {
        public int Variable{get;set;}
    	public List<AnotherClass> ListVariable {get;set;}
    	
    	public override string ToString()
    	{
    	    return string.Join(", ", new string[]{ 
    		    string.Format("Variable= {0}", + this.Variable),
    			string.Format("ListVariable= [{0}]", string.Join(", ", this.ListVariable))
    		});
    	}
    }
    
    public class AnotherClass
    {
        public string Variable{get;set;}
    	public int IntVariable{get;set;}
    	
    	public override string ToString()
    	{
    	    return string.Join(", ", new string[]{
    		    string.Format("Variable={0}", this.Variable),
    			string.Format("IntVariable={0}", this.IntVariable)
    		});
    	}
    }
