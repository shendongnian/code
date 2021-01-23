    [TestClass]
    public class ConstructorInfoExtensionsTest
    {
    	class PublicConstructors
    	{
    		// First
    		public PublicConstructors() : this( true ) {}
    
    		// Second
    		public PublicConstructors( bool one ) : this( true, true ) {}
    
    		// Final
    		public PublicConstructors( bool one, bool two ) {}
    
    		// Alternate final
    		public PublicConstructors( bool one, bool two, bool three ) {}
    	}
    
    	class PrivateConstructors
    	{
    		// First
    		PrivateConstructors() : this( true ) {}
    
    		// Second
    		PrivateConstructors( bool one ) : this( true, true ) {}
    
    		// Final
    		PrivateConstructors( bool one, bool two ) {}
    
    		// Alternate final
    		PrivateConstructors( bool one, bool two, bool three ) {}
    	}
    
    	class TripleBaseConstructors : DoubleBaseConstructors
    	{
    		public TripleBaseConstructors() : base() { }
    		public TripleBaseConstructors( bool one ) : base( one ) { }
    	}
    
    	class DoubleBaseConstructors : BaseConstructors
    	{
    		public DoubleBaseConstructors() : base() {}
    		public DoubleBaseConstructors( bool one ) : base( one ) {}
    	}
    
    	class BaseConstructors : Base
    	{
    		public BaseConstructors() : base() {}
    		public BaseConstructors( bool one ) : base( one ) {}
    	}
    
    	class Base
    	{
    		// No parameters
    		public Base() {}
    
    		// One parameter
    		public Base( bool one ) {} 
    	}
    
    	class ContentConstructor
    	{
    		public ContentConstructor()
    		{
    			SomeMethod();
    		}
    
    		public ContentConstructor( bool one )
    		{
    			int bleh = 0;
    		}
    
    		bool setTwo;
    		public ContentConstructor( bool one, bool two )
    		{
    			setTwo = two;
    		}
    
    		void SomeMethod() {}
    	}
    
    	[TestMethod]
    	public void CallsOtherConstructorTest()
    	{			
    		Action<ConstructorInfo[]> checkConstructors = cs =>
    		{
    			ConstructorInfo first = cs.Where( c => c.GetParameters().Count() == 0 ).First();
    			Assert.IsTrue( first.CallsOtherConstructor() );
    			ConstructorInfo second = cs.Where( c => c.GetParameters().Count() == 1 ).First();
    			Assert.IsTrue( second.CallsOtherConstructor() );
    			ConstructorInfo final = cs.Where( c => c.GetParameters().Count() == 2 ).First();
    			Assert.IsFalse( final.CallsOtherConstructor() );
    			ConstructorInfo alternateFinal = cs.Where( c => c.GetParameters().Count() == 3 ).First();
    			Assert.IsFalse( alternateFinal.CallsOtherConstructor() );
    		};
    
    		// Public and private constructors.
    		checkConstructors( typeof( PublicConstructors ).GetConstructors() );
    		checkConstructors( typeof( PrivateConstructors ).GetConstructors( BindingFlags.NonPublic | BindingFlags.Instance ) );
    
    		// Inheritance.
    		Action<ConstructorInfo[]> checkBaseConstructors = cs =>
    		{
    			ConstructorInfo noParameters = cs.Where( c => c.GetParameters().Count() == 0 ).First();
    			ConstructorInfo oneParameter = cs.Where( c => c.GetParameters().Count() == 1 ).First();
    
    			// Only interested in constructors specified on this type, not base constructors,
    			// thus calling a base constructor shouldn't qualify as 'true'.
    			Assert.IsFalse( noParameters.CallsOtherConstructor() );
    			Assert.IsFalse( oneParameter.CallsOtherConstructor() );
    		};
    		checkBaseConstructors( typeof( BaseConstructors ).GetConstructors() );
    		checkBaseConstructors( typeof( DoubleBaseConstructors ).GetConstructors() );
    		checkBaseConstructors( typeof( TripleBaseConstructors ).GetConstructors() );
    
    		// Constructor with content.
    		foreach( var constructor in typeof( ContentConstructor ).GetConstructors() )
    		{
    			Assert.IsFalse( constructor.CallsOtherConstructor() );
    		}				
    	}
    }
