	public class TestQuery : IFlatFileQuery {
		private readonly int _sleepTime;
		public IEnumerable<Entity> Run() {
			Thread.Sleep(_sleepTime);
			return new[] { new Entity() };
		}
		public TestQuery(int sleepTime) {
			_sleepTime = sleepTime;
		}
	}
	internal static class Program {
		private static void Main() {
			Stopwatch stopwatch = Stopwatch.StartNew();
			var queries = new IFlatFileQuery[] {
				new TestQuery(2000),
				new TestQuery(3000),
				new TestQuery(1000)
			};
			foreach (var entity in queries.AsParallel().SelectMany(ffq => ffq.Run()))
				Console.WriteLine("Yielded after {0:N0} seconds", stopwatch.Elapsed.TotalSeconds);
			Console.ReadKey();
		}
	}
