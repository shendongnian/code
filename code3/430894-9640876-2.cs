    InitializeComponent();
    this.DataContext = this;
    Files = new ObservableCollection<FileInfo>();
    foreach (string datei in dirFiles)
    {
       var fName = System.IO.Path.GetFileName(datei);
       BitmapImage bitMap = new BitmapImage();
       bitMap.BeginInit();
       bitMap.UriSource = new Uri(@"tag.jpg", UriKind.Relative);
       bitMap.EndInit();
       Files.Add(new FileInfo(){FileName=fName, FileImage = bitMap});
    }
