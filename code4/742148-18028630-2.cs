	public class Tree<T> : List<Tree<T>>
	{
		public Tree(T value, IEnumerable<IEnumerable<T>> inner)
		{
			this.Value = value;
			this.AddRange(inner
				.ToLookup(xs => xs.FirstOrDefault(), xs => xs.Skip(1))
				.Where(xs => xs.Key != null)
				.Select(xs => new Tree<T>(xs.Key, xs)));
		}
		public T Value { get; set; }
	}
