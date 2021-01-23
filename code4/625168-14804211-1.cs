    public partial class MainWindow : Window
    {
        private ObservableCollection<Foo> _fileList = new ObservableCollection<Foo>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in Directory.GetDirectories(@"C:\StackOverflow"))
            {
                FileList.Add(new Foo
                {
                    Name = item,
                    FileList = new ObservableCollection<Bar>(Directory.GetFiles(item).Select(x => new Bar { FileInfo = new FileInfo(x) }))
                });
            }
        } 
        public ObservableCollection<Foo> FileList
        {
            get { return _fileList; }
            set { _fileList = value; }
        }
    }
    public class Foo
    {
        public string Name { get; set; }
        public ObservableCollection<Bar> FileList { get; set; }
    }
    public class Bar
    {
        public FileInfo FileInfo { get; set; }
    }
