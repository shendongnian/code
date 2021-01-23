	public class NotifiableConcurrentBag<T> : ConcurrentBag<T> where T : class {
		public int CountOfAdditions { get; set; }
		public new void Add(T item) {
			base.Add(item);
			Console.WriteLine("Overloaded!");
			CountOfAdditions++;
		}	
	}
