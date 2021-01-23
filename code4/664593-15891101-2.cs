    public class DefaultDocumentSection : ConfigurationSection
    {
        private FilesCollection _files;
        public FilesCollection Files
        {
            get
            {
                if (_files == null)
                {
                    _files = (FilesCollection)base.GetCollection("files", typeof(FilesCollection));
                }
    
                return _files;
            }
        }
    
    }
    public class FilesCollection : ConfigurationElementCollectionBase<FileElement>
    {
        protected override FileElement CreateNewElement(string elementTagName)
        {
            return new FileElement();
        }
    }
    
    public class FileElement : ConfigurationElement
    {
        public string Value { get { return (string)base["value"]; } }
    }
