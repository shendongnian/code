	public class ClassA
	{
		public void methodA(int a) 
		{
			Console.WriteLine("Without ref");
		}
		public void methodA(ref int a) 
		{
			Console.WriteLine("With ref");
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			int i = 1;
			var a = new ClassA();
			
			a.methodA(i);
			a.methodA(ref i);
			Console.ReadKey(true);
		}
	}
