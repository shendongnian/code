    internal class FileDetail
    {
        public string Display { get; set; }
        public string FullName { get; set; }
    }
    public partial class Example: Form // This is just widows form. InitializeComponent is implemented in separate file.
    {
        public Example()
        {
            InitializeComponent();
            filesList.SelectionChangeCommitted += filesListSelectionChanged;
            filesList.Click += filesListClick;
            filesList.DisplayMember = "Display";
        }        
        private void filesListClick(object sender, EventArgs e)
        {
            var dir = new DirectoryInfo(_baseDirectory);
            filesList.Items.AddRange(
                (from fi in dir.GetFiles()
                select new FileDetail
                {
                    Display = Path.GetFileNameWithoutExtension(fi.Name),
                    FullName = fi.FullName
                }).ToArray()
            );
        }
        private void filesListSelectionChanged(object sender, EventArgs e)
        {            
            var text = File.ReadAllText(
                (filesList.SelectedItem as FileDetail).FullName
            );
            
            fileContent.Text = text;
        }
        private static readonly string _baseDirectory = @"C:/Windows/System32/";
    }
