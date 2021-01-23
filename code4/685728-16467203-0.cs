        public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
        {
            return (f1.Name == f2.Name &&
                    f1.Length == f2.Length &&
                    f1.Directory == f2.Directory.replace(pathA, pathB) );
        }
