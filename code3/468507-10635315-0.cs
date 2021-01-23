    /// <summary>
    /// FileStream that automatically delete the file when closing
    /// </summary>
    public class AutoDeleteFileStream : FileStream
    {
        private string _fileName;
    
        public AutoDeleteFileStream(string fileName, FileMode fileMode, FileAccess fileAccess)
            : base(fileName, fileMode, fileAccess)
        {
            this._fileName = fileName;
        }
    
        public AutoDeleteFileStream(string fileName, FileMode fileMode)
            : base(fileName, fileMode)
        {
            this._fileName = fileName;
        }
    
        public override void Close()
        {
            base.Close();
            if (!string.IsNullOrEmpty(_fileName))
                File.Delete(_fileName);
        }
    }
