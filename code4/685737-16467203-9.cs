        public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
        {
            return (f1.Name == f2.Name &&
                    f1.Length == f2.Length &&
                    f1.DirectoryName.replace(pathA, pathB) == f2.DirectoryName.replace(pathA, pathB) );
        }
