    public ScanItem(Node node)
    {                        
        this.Name = node.Name;
        this.FullPath = node.Value.FullName;
        DirectoryInfo di = new DirectoryInfo(this.FullPath);  //<<<<<<<
        this.Size = di.GetDirectorySize();                    //<<<<<<<
        foreach(var child in node.Children)
        {
             this.Children.add(new ScanItem(child));
        }
    }
