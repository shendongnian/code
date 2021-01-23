     public partial class OpenFileDialog : UserControl
            {
             public class Folder
                {
                    public Folder() { Folders = new List<Folder>(); }
                    public string Name { get; set; }
                    public List<Folder> Folders { get; set; }
                }
    
    
             private IsolatedStorageFile _ifs;
    
            public OpenFileDialog()
                {
                InitializeComponent();
    
                Folders = new ObservableCollection<Folder>();
                var _ifs = IsolatedStorageFile.GetUserStoreForApplication();
                var folder = new Folder
                    {
                        Name = "Root",
                        Folders = (from c in _ifs.GetDirectoryNames()
                            select new Folder
                            {
                                Name = c,
                                Folders = LoadFolders(c)
                            }).ToList()
                    };
                    Folders.Add(folder);
                    FolderTreeView.DataContext = this;
                }
    
    
    
            private ObservableCollection<Folder> _Folders;
            public ObservableCollection<Folder> Folders
                {
                get { return _Folders; }
                set { _Folders = value; }
                }
               
            private List<Folder>LoadFolders(string folderName)
                {
                if(folderName == null)
                    return null;
                return (from c in _ifs.GetDirectoryNames(folderName + "\\*.*")
                    select new Folder
                    {
                        Name = c,
                        Folders = LoadFolders(c)
                    }).ToList();
                }
    
            }
