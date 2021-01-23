     public abstract class FolderComponent : IEnumerable
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public List<string[]> Rules { get; set; }
        public abstract void AddFolder(FolderComponent folderComponent);
        public abstract IEnumerator GetEnumerator();
        public abstract void AssignRules();
        public abstract List<FolderComponent> GetAllItems();
    }
    public class Folder : FolderComponent
    {
        public IList<FolderComponent> FolderComponents { get; set; }
        public Folder(string path)
        {
            FullName = path;
            FolderComponents = new List<FolderComponent>();
            Rules = new List<string[]>();
        }
        public override void AddFolder(FolderComponent folderComponent)
        {
            FolderComponents.Add(folderComponent);
        }
        public override IEnumerator GetEnumerator()
        {
            return FolderComponents.GetEnumerator();
        }
        public override void AssignRules()
        {
            // some code
            string[] rules = new string[] { "Read", "Write", "Execute" };
            Rules.Add(rules);
        }
        public override List<FolderComponent> GetAllItems()
        {
            var resultItems = new List<FolderComponent> {this};
            foreach (var folderComponent in FolderComponents)
            {
                resultItems.AddRange(folderComponent.GetAllItems());
            }                        
            return resultItems;
        }
    }
    public class Program
    {
        private static FolderComponent GetFolders(string path)
        {
            FolderComponent folder = new Folder(path);
            folder.AssignRules();
            foreach (var directory in Directory.GetDirectories(path))
            {
                folder.AddFolder(GetFolders(directory));
            }
            return folder;
        }
        public static void Main()
        {
            FolderComponent rootfolder = GetFolders(@"D:\4Share");
            var allItems = rootfolder.GetAllItems();
            foreach (var folderComponent in allItems)
            {
                Console.WriteLine(folderComponent.FullName);                
            }
            Console.ReadLine();
        }
