    BindingList<string> _Files = new BindingList<string>();
    public Form1() {
      InitializeComponent();
      _Files.ListChanged += new ListChangedEventHandler(Files_ListChanged);
      fileSystemWatcher1.Deleted += fileSystemWatcher1_Deleted;
      fileSystemWatcher1.Created += fileSystemWatcher1_Created;
      fileSystemWatcher1.Renamed += fileSystemWatcher1_Renamed;
      fileSystemWatcher1.Path = @"C:\TestLoadFiles\";
      foreach (string f in Directory.GetFiles(fileSystemWatcher1.Path)) {
        _Files.Add(Path.GetFileName(f));
      }
      listBox1.DataSource = _Files;
    }
    private void Files_ListChanged(object sender, ListChangedEventArgs e) {
      button1.Enabled = (_Files.Count > 0);
    }
    private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e) {
      _Files[_Files.IndexOf(e.OldName)] = e.Name;
    }
    private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e) {
      _Files.Remove(e.Name);
    }
    private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e) {
      _Files.Add(e.Name);
    }
