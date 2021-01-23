    public class MyClass
    {
	    public enum MyEnum 
        {
        	[Display(Name="ONE")]
			One,
			// No DisplayAttribute
			Two
		}
        public void UseMyEnum()
        {
            MyEnum foo = MyEnum.One;
            MyEnum bar = MyEnum.Two;
            Console.WriteLine(foo.GetDisplayName());
            Console.WriteLine(bar.GetDisplayName());
        }
    }
    // Output:
    //
    // ONE
    // Two
