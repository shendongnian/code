	public static class SortDescriptorExtensions
	{
		public static void Expand(this IEnumerable<SortDescriptor> sortDescriptors)
		{
			foreach (var sortDescriptor in sortDescriptors)
			{
				sortDescriptor.Member = sortDescriptor.Member.Replace('_', '.');
			}
		}
	}
