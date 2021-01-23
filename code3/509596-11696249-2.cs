    public class InstallerObject
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string Path { get; set; }
        public int Build { get; set; }
        public bool Configurable { get; set; }
        public int AverageInstallTime { get; set; }
        public bool IsSelected { get; set; }
    }
    public class ProductType
    {
        public string Description { get; set; }
        public ReadOnlyObservableCollection<InstallerObject> AvailableInstallerObjects
        {
            get;
            set; 
        }
        public override string ToString()
        {
            return this.Description;
        }
    }
