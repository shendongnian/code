	public class A
	{
		public virtual void Process()
		{
			// Do algorithm for type A
		}
	}
	public class B : A
	{
		public override void Process()
		{
			// Do algorithm for type B
		}
	}
	
	public void ProcessItems(List<A> items)
	{
		foreach(A item in items)
			item.Process();	// Call A.Process() or B.Process() depending on type
	}
