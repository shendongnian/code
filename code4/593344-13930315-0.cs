        public static class Storage
    {
        private static IReadOnlyList<StorageFile> _files;
        static Storage()
        {
            _files = GetFilesAsync("Assets").Result;
        }
        private async static Task<IReadOnlyList<StorageFile>> GetFilesAsync(string relativeFolderPath)
        {
            var folder = await Package.Current.InstalledLocation.GetFolderAsync("Assets").AsTask().ConfigureAwait(false);
            return await folder.GetFilesAsync(CommonFileQuery.OrderByName).AsTask().ConfigureAwait(false);
        }
        public static bool Exists(string filename)
        {
            var file = _files.FirstOrDefault(x => x.Name == filename);
            return file != null;
        }
    }
