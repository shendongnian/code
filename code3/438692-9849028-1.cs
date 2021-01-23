    class PublicConstructors
    {
    	// First
    	public PublicConstructors() : this( true ) {}
    
    	// Second
    	public PublicConstructors( bool one ) : this( true, true ) {}
    
    	// Final
    	public PublicConstructors( bool one, bool two ) {}
    }
    
    [TestMethod]
    public void CallsOtherConstructorTest()
    {
    	ConstructorInfo[] publicConstructors = typeof( PublicConstructors ).GetConstructors();
    	ConstructorInfo first = publicConstructors.Where( c => c.GetParameters().Count() == 0 ).First();
    	ConstructorInfo second = publicConstructors.Where( c => c.GetParameters().Count() == 1 ).First();
    	ConstructorInfo final = publicConstructors.Where( c => c.GetParameters().Count() == 2 ).First();
    
    	Assert.IsTrue( first.CallsOtherConstructor() );
    	Assert.IsTrue( second.CallsOtherConstructor() );
    	Assert.IsFalse( final.CallsOtherConstructor() );
    }
