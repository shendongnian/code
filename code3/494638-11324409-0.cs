	public interface IHasInteger
	{
		int Value { get; }
	}
	public class HasInteger : IHasInteger
	{
		public int Value { get { return 1; } }
	}
	public class AlsoHasInteger : IHasInteger
	{
		public int Value { get { return 2; } }
	}
	class Program
	{
		static void Main(string[] args)
		{
			var a = new HasInteger();
			var b = new AlsoHasInteger();
			var c = new object();
			Console.WriteLine(GetInteger(a));
			Console.WriteLine(GetInteger(b));
			Console.WriteLine(GetInteger(c));
			Console.ReadLine();
		}
		private static int GetInteger(object o)
		{
			if (o is IHasInteger)
			{
				int x = ((IHasInteger)o).Value;
				return x;
			}
			return 0;
		}
	}
