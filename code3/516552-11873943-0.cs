    class MyPathItem
    {
        public string Path { get; set; }
        public override string ToString() 
        {
            return System.IO.Path.GetFileName(Path);
        }
    }
    ...
    foreach (var fullPath in GetFullPaths())
    {
        myListBox.Add(new MyPathItem { Path = fullPath });
    }
