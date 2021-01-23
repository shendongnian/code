	public class PriorityQueue<TK, TV>
	{
		private readonly SortedDictionary<TK, Queue<TV>> _D = new SortedDictionary<TK, Queue<TV>> ();
		public void Enqueue (TK key, TV value)
		{
			Queue<TV> list;
			if (!_D.TryGetValue (key, out list)) {
				list = new Queue<TV> ();
				_D.Add (key, list);
			}
			list.Enqueue (value);
			Count++;
		}
		public int Count
		{
			get;
			private set;
		}
		public TV Dequeue ()
		{
			var first = _D.First ();
			var item = first.Value.Dequeue ();
			if (!first.Value.Any ()) {
				_D.Remove (first.Key);
			}
			return item;
		}
		public IEnumerable<TV> Values
		{
			get
			{
				var keys = _D.Keys.ToArray ();
				foreach (var key in keys) {
					foreach (var item in _D[key]) {
						yield return item;
					}
				}
			}
		}
	}
