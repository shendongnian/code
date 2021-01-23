    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        ListBox toAdd = new ListBox();
        toAdd.Location = new Point(20,20);
        toAdd.Size = new Size(200,200);
        this.Controls.Add(toAdd);
    }
