	class Program
	{
		static void Main(string[] args)
		{
			var p = new Program();
			p.DoStuff();
		}
		void DoStuff()
		{
			int i = 19;
			Expression<Func<int>> j = () => i + 10;
			var k = (((j.Body as BinaryExpression).Left as MemberExpression).Expression as ConstantExpression).Value;
			Console.ReadLine();
		}
	}
