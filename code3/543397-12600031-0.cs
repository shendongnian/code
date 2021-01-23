    public class Directory
    {
        private FileEntry[] _file_entries;
        public virtual FileEntry[] file_entries 
        {
            get { return _file_entries; }
            set{_file_entries = value;} 
        }
    }
    public class AudioDirectory
    {
        private AudioFileEntry[] _sub_file_entries;
        public new AudioFileEntry[] file_entries 
        {
            get { return _sub_file_entries; }
            set{_sub_file_entries = value;} 
        }
    }
