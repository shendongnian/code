	/// <summary>
	/// A class to keep a tally of a certain item for.
	/// </summary>
	/// <typeparam name="T">The type of the item to keep a tally for.</typeparam>
	public class Tally<T> {
		public Tally(T initialTallyItem, ulong initialCountValue = 0) {
			this.Item = initialTallyItem;
			this.Count = initialCountValue;
		}
		public T Item { get; set; }
		public ulong Count { get; set; }
	}
