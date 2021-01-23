    public static bool operator ==(Person one, Person two)
    {
    	return one.Id == two.Id && one.Name == two.Name;
    }
    public static override bool Equals(Person one, Person two)
    {
    	return one == two;
    }
    public override bool Equals(object obj)
    {
    	return obj is Person && ((Person)obj) == this;
    }
    public bool Equals(Person other)
    {
    	return other == this;
    }
    public override int GetHashCode()
    {
    	unchecked
    	{
    		return 17 * Id * 31 * Name.GetHashCode();
    	}
    }
