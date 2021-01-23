    IList<TileInfo> tiles = tileSource.Schema.GetTilesInView(extent, level);
    List<Task> renderingTasks = new List<Task>();
    
    foreach (TileInfo info in tiles) 
    {
       TileInfo closingInfo = info;
       renderingTasks.Add(Task.Factory.StartNew(new Action(delegate {
                          Console.WriteLine(Task.CurrentId +"Info object"+ closingInfo.GetHashCode()); }})));
    }
