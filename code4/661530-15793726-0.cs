    abstract class DirectoryChildItem
    {
        public string Name { get; set; }
    }
    class Directory : DirectoryChildItem
    {
        public List<DirectoryChildItem> Childs { get; set; }
    }
    
    class File : DirectoryChildItem
    {
    }
