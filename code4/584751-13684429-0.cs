        public List<string> FileNames
        {
            get { return _SOFiles.Select(p => p.FileName).ToList(); }
            private set { }
        }
        public List<string> Filepaths
        {
            get { return _SOFiles.Select(p => p.FilePath).ToList(); }
            private set { }
        }
