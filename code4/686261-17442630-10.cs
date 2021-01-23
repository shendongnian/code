	public static class DataSourceRequestExtensions
	{
		/// <summary>
		/// Enable flattened properties in the ViewModel to be used in DataSource.
		/// </summary>
		public static void Deflatten(this DataSourceRequest dataSourceRequest)
		{
			foreach (var filterDescriptor in dataSourceRequest.Filters.Cast<FilterDescriptor>())
			{
				filterDescriptor.Member = DeflattenString(filterDescriptor.Member);
			}
			foreach (var sortDescriptor in dataSourceRequest.Sorts)
			{
				sortDescriptor.Member = DeflattenString(sortDescriptor.Member);
			}
		}
		private static string DeflattenString(string source)
		{
			return source.Replace('_', '.');
		}
	}
