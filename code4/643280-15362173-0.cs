    foreach (string file in Directory.GetFiles(dir))
        {
           //creating objects for each file in the directory
           FileObject fileObject = new FileObject();
           FileInfo info = new FileInfo(file);
           currentfile = file.ToString();
           fileObject.name = info.Name.ToString();
           fileObject.path = file.ToString();
           fileObject.createdDate = info.CreationTime.ToString();
           FileList.Add(fileObject);
           //event handler triggered
           OnFileNameChanged(name);
        }
    //event handler code
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnFileNameChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
