    class FileListBoxItem
    {
        public string FileFullname { get; set; }
        public override string ToString() {
            return Path.GetFileName(FileFullname);
        }
    }
