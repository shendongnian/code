	public abstract class absclass1
	{
		protected void Checker() {
			Console.WriteLine("from absclass1");
		}
	}
	public class sample1 : absclass1
	{
		protected void Checker() {
			Console.WriteLine("from sample1");
			base.Checker();
		}
	}
