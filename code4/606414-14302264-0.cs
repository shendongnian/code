	    /// see: http://msdn.microsoft.com/en-us/library/ff714955.aspx
		///     
		/// The method has been modified from version that appears in the referenced article to support DbContext in EF 4.1 ->
		/// 
		/// </summary>
		public static class ModelExtensions {
			public static IQueryable<T> Include<T>
					(this IQueryable<T> sequence, string path) where T : class {
				var dbQuery = sequence as DbQuery<T>;
				if (dbQuery != null) {
					return dbQuery.Include(path);
				}
				return sequence;
			}
		}
