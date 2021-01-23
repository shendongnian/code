    public class Directory
    {
        public virtual FileEntry[] file_entries { get; set; }
    }
    
    public class AudioDirectory : Directory
    {
        public override FileEntry[] file_entries { 
            get 
            {
               return new AudioFileEntry[] { new AudioFileEntry() };
            }
            set 
            {
               //(other code omitted)
            } 
        }
    }
