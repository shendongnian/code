    if(e.AddedItems.Length > 0)       // make sure there is at least one item..
    {
       MainViewModel firstItem = e.AddedItems[0] as MainViewModel;    // cast..
       if(firstItem != null)                                          // if not null..
       {
           string fileName = firstItem.FileName;                      // get the file name
       }
    }
