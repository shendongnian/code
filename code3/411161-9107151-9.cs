    private List<Control> AddedItems = new List<Controls>();
    private int OffsetY = 0;
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        ListBox toAdd = new ListBox();
        if(AddedItem.Last().Point.Y == OffsetY) // just an example of reusing previously added items.
        {
             toAdd.Location = new Point(20, OffsetY);
             toAdd.Size = new Size(200,200);
             AddedItems.Add(toAdd);
             this.Controls.Add(toAdd);
        }
        OffsetY += 200;
    }
