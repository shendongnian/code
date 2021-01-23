	public class A
	{
		public virtual string attr 
		{		
			get { return "Class A" }
		}
		public void getAttribute(){
			 Console.Write("Attribute : " + attr);
		}
	}
	public class B : A
	{
		public override string attr 
		{		
			get { return "Class B"; }
		}
	}
	var b = new B();
	b.getAttribute();
