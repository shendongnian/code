	static class Helpers {
		public static void DeleteOldFiles(string folderPath, uint maximumAgeInDays,
                                          params string[] filesToExclude) {
			DateTime minimumDate = DateTime.Now.AddDays(-maximumAgeInDays);
            var filesToDelete = Directory.EnumerateFiles(folderPath)
                .Where(x => !IsExcluded(x, filesToExclude));
            foreach (var eligibleFileToDelete in filesToDelete)
				DeleteFileIfOlderThan(eligibleFileToDelete, minimumDate);
		}
		private const int RetriesOnError = 3;
		private const int DelayOnRetry = 1000;
		private static bool IsExcluded(string item, string[] exclusions) {
            return exclusions.Contains(item, StringComparer.CurrentCultureIgnoreCase);
		}
		private static void DeleteFileIfOlderThan(string path, DateTime date)
		{
			for (int i = 0; i < RetriesOnError; ++i) {
				try {
					var file = new FileInfo(path);
					if (file.CreationTime < date)
						file.Delete();
				}
				catch (IOException) {
					System.Threading.Thread.Sleep(DelayOnRetry);
				}
				catch (UnauthorizedAccessException) {
					System.Threading.Thread.Sleep(DelayOnRetry);
				}
			}
		}
	}
