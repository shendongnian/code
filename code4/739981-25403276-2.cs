    using System;
    using System.Reactive.Subjects;
	namespace RX_2
	{
		public static class Program
		{
			static void Main(string[] args)
			{
				Subject<int> stream = new Subject<int>();
				stream.Subscribe(
					o =>
					{
						Console.Write(o);
					});
				stream.Subscribe(
					o =>
					{
						Console.Write(o);
					});
				for (int i = 0; i < 5; i++)
				{
					stream.OnNext(i);
				}
				Console.ReadKey();
			}
		}
	}
