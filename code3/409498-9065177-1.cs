        public static string GetRelativePath(FileSystemInfo path1, FileSystemInfo path2)
        {
            if (path1 == null) throw new ArgumentNullException("path1");
            if (path2 == null) throw new ArgumentNullException("path2");
            Func<FileSystemInfo, string> getFullName = delegate(FileSystemInfo path)
            {
                string fullName = path.FullName;
                if (path is DirectoryInfo)
                {
                    if (fullName[fullName.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                    {
                        fullName += System.IO.Path.DirectorySeparatorChar;
                    }
                }
                return fullName;
            };
            string path1FullName = getFullName(path1);
            string path2FullName = getFullName(path2);
            Uri uri1 = new Uri(path1FullName);
            Uri uri2 = new Uri(path2FullName);
            Uri relativeUri = uri1.MakeRelativeUri(uri2);
            return relativeUri.OriginalString;
        }
