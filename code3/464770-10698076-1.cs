        /// <summary>
        /// Gets the long name of a given file.
        /// </summary>
        /// <param name="shortFullPath">The short full path to the file. Input path segments must be short names.</param>
        /// <returns>The corresponding long file name.</returns>
        public string GetLongFileName(string shortFullPath)
        {
            if (shortFullPath == null)
                throw new ArgumentNullException("shortFullPath");
            string dirPath = Path.GetDirectoryName(shortFullPath);
            string fileName = Path.GetFileName(shortFullPath);
            Directory dir = GetDirectory(dirPath);
            if (dir == null)
                return fileName;
            string lfn;
            if (dir._lfns.TryGetValue(Path.GetFileName(shortFullPath), out lfn))
                return lfn;
            return fileName;
        }
        /// <summary>
        /// Gets the long path to a given file.
        /// </summary>
        /// <param name="shortFullPath">The short full path to the file. Input path segments must be short names.</param>
        /// <returns>The corresponding long file path to the file or null if not found.</returns>
        public string GetLongFilePath(string shortFullPath)
        {
            if (shortFullPath == null)
                throw new ArgumentNullException("shortFullPath");
            string path = null;
            string current = null;
            foreach (string segment in shortFullPath.Split(Path.DirectorySeparatorChar))
            {
                if (current == null)
                {
                    current = segment;
                    path = GetLongFileName(current);
                }
                else
                {
                    current = Path.Combine(current, segment);
                    path = Path.Combine(path, GetLongFileName(current));
                }
            }
            return path;
        }
