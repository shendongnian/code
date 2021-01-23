	public static class StorageFileExtensions
	{
		/// <summary>
		///     Touches a file to update the DateModified property.
		/// </summary>
		public static async Task TouchAsync(this StorageFile file)
		{
			using (var touch = await file.OpenTransactedWriteAsync())
			{
				await touch.CommitAsync();
			}
		}
	}
