    public Folder : IFolder
    {
        ...
        public ICollection<IFolder> SubFolders { get; set; }
        public ICollection<IFile> Files { get; set; }
    }
