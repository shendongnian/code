    public class FileObjectWrapper
    {
        private FileObject fileObject_;
        
        FileObjectWrapper()
        {
            fileObject_ = new FileObject();
        }
        FileObjectWrapper(FileObject fo)
        {
            fileObject_ = fo;
        }
        public string FilePath
        {
            get { return fileObject_.filePath; }
            set { fileObject_.filePath = value; }
        }
        public string FileState
        {
            get { return fileObject_.fileState; }
            set { fileObject_.fileState= value; }
        }
        public bool Selected { get; set; }
    }
