	public class ParentClass
	{
		public void AddSomething(double num) {
			System.Console.WriteLine(ParentNum + num);
		}
	
		public double ParentNum { get; set; }
	}
	
	public class ChildClass : ParentClass
	{
		public void AddSomething() {
			base.AddSomething(ChildNum);
		}
	
		public double ChildNum { get; set; }
	}
