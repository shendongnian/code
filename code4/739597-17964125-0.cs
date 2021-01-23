    public class ProblemData
    {
    	//whatever...
    	public override string ToString()
    	{
    		return string.format("{0}", this.SomeObject); //set proper display
    	}
    }
    
    public class YourClass()
    {
    	//...
    	public ProblemData ProblemData{ get; set;}
    }
