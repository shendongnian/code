    public partial class Foo : IFoo
    {
    	string IFoo.Bar
    	{
    		get
    		{
    			return this.Bar;  // Returns the private value of your existing Bar private field
    		}
    		set
    		{
    			this.Bar = value;
    		}
    	}
    }
