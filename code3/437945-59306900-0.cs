        private IEnumerable<string> RecursiveFileSearch(string path, string pattern, ICollection<string> filePathCollector = null)
        {
            try
            {
                filePathCollector = filePathCollector ?? new LinkedList<string>();
                var matchingFilePaths = Directory.GetFiles(path, pattern);
                foreach(var matchingFile in matchingFilePaths)
                {
                    filePathCollector.Add(matchingFile);
                }
                var subDirectories = Directory.EnumerateDirectories(path);
                foreach (var subDirectory in subDirectories)
                {
                    RecursiveFileSearch(subDirectory, pattern, filePathCollector);
                }
                return filePathCollector;
            }
            catch (Exception error)
            {
                bool isIgnorableError = error is PathTooLongException ||
                    error is UnauthorizedAccessException;
                if (isIgnorableError)
                {
                    return Enumerable.Empty<string>();
                }
                throw error;
            }
        }
