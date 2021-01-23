    public class FolderPath
    {
        public string Directory { get; set; }
        public Image Status { get; set; }
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {                    
        ObservableCollection<FolderPath> _FolderCollection = new ObservableCollection<FolderPath>();
        Image i = Image();
        i.Height = 20;
        i.Source = new BitmapImage(new Uri(@"C:\Users\smk\Documents\Visual Studio 2010\Projects\Folder_locker\Folder_locker\folder_lock.ico", UriKind.Absolute));
        listView1.Items.Add(new FolderPath { Directory = "something", Status = i } )
    }
