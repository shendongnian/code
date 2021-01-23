    public class Particle
    {
    	public int SomeField;
    	
    	public Particle Copy()
    	{
    		return new Particle { SomeField = this.SomeField };
    	}	
    	
    	public Particle(Particle copyFrom)
    	{
    		this.SomeField = copyFrom.SomeField;
    	}
    }
