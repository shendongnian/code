    public Folder : IFolder
    {
        ...
        private ICollection<IFolder> _subFolders = new ObservableCollection<IFolder>();
        public ICollection<IFolder> SubFolders
        {
            get { return _subFolders; }
            set { _subFolders = value; }
        }
    
        private ICollection<IFile> _files = new ObservableCollection<IFile>();
        public ICollection<IFile> Files
        {
            get { return _files; }
            set { _files = value; }
        }
        ...
    }
