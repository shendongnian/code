	public static class TreeNodeEx
	{
		public static IEnumerable<TreeNode> AddRange ( this TreeNode collection, IEnumerable<TreeNode> nodes )
		{
			collection.Nodes.AddRange ( nodes.ToArray () );
			return new[] { collection };
		}
	}
