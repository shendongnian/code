	public interface IHaveAAndB
	{
		bool A { get; set; }
		bool B { get; set; }
	}
	public class Foo : IHaveAAndB
	{     
		public bool A { get; set; }     
		public bool B { get; set; }     
		public bool C { get; set; }     
		public bool D { get; set; }     
		public bool E { get; set; } 
	}  
	public class Bar : IHaveAAndB
	{     
		public bool A { get; set; }     
		public bool B { get; set; } 
	} 
	// Disclaimer - I've not tested whether this compiles but essentially
	// make the method generic and call it using the interface type
	// and you can then do a copy from one set of properties to the other
	// e.g. CopyInterfaceProperties<IHaveAAndB>(new Foo(), new Bar());
	public static void CopyInterfaceProperties<T>(T e1, T e2)     
	{         
		foreach (var prop in typeof(T).GetProperties())         
		{          
			if (prop.CanRead && prop.CanWrite)	
			{
			    var value = prop.GetValue(e2, null)
			    prop.SetValue(e1, value, null);   
			}
		}     
	} 
