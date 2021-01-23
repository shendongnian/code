         public class FolderItems : INotifyPropertyChanged
            {
        
                public event PropertyChangedEventHandler PropertyChanged;
        
        
        
                //Temp Data
                public FolderItems()
                {
                   
                      
      //Add System.windows.Form assampbly. 
                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
    
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    FilePathList = ProcessFiles(dialog.SelectedPath);
                      
        
                    ////var directories = new System.IO.DirectoryInfo("C:\\Windows\\").GetFiles().Select(x => x.Name);
        
                    //foreach (var file in directories)
                    //{
                    //    FilePathList.Add(file);
                    //}
        }
                }
        
                private ObservableCollection<String> ProcessFiles(string path)
                {
                    string[] directories;
                    ObservableCollection<String> fileList = new ObservableCollection<string>();
                    var files = new System.IO.DirectoryInfo(path).GetFiles("*.dll").Select(x => x.Name); //Directory.GetFiles(path).Where(name => name.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase));
                    fileList = new ObservableCollection<String>(files.ToList<String>());
        
        
                    //your processing further
                    //directories = Directory.GetDirectories(path);
                    //foreach (string directory in directories)
                    //{
                    //    // Process each directory recursively
                    //    ProcessFiles(directory);
                    //}
        
                    return fileList;
                }
        
                protected void Notify(string propertyName)
                {
                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
        
                private ObservableCollection<String> _pathList = new ObservableCollection<string>();
        
                public ObservableCollection<String> FilePathList
                {
                    get { return _pathList; }
                    set
                    {
                        if (value != _pathList)
                        {
                            _pathList = value;
                            Notify("FilePathList");
                        }
                    }
                }
        
            }
