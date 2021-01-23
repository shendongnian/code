    public class MyClass
    {
        public string Name { get; set; }
    	public override int GetHashCode()
    	{
    		return Name.GetHashCode();
    	}
    	public override bool Equals(object other)
    	{
    		return this.Name == ((MyClass)other).Name;
    	}
    }
