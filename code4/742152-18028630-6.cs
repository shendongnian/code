	public class Tree<T> : List<Tree<T>>
	{
		public Tree(T value, IEnumerable<Tree<T>> children)
		{
			this.Value = value;
			this.AddRange(children);
		}
		public T Value { get; set; }
	}
