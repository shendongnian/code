    public class Directory
    {
        private FileEntry[] _file_entries;
        public virtual FileEntry[] file_entries 
        {
            get { return _file_entries; }
            set{_file_entries = value;} 
        }
    }
    public class AudioDirectory : Directory
    {
        public new AudioFileEntry[] file_entries
        {
            get { return (AudioFileEntry[])base.file_entries; }
            set { base.file_entries = value; }
        }
    }
