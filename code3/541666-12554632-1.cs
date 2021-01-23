    Application.Current.Dispatcher.Invoke((Action)(delegate
       {
           GridView grid = new GridView();
           grid.Columns.Add((GridViewColumn)myresourcedictionary["gridDirFileName"]);
           grid.Columns.Add((GridViewColumn)myresourcedictionary["gridDirFileType"]);
           grid.Columns.Add((GridViewColumn)myresourcedictionary["gridDirFileDataModified"]);
           grid.Columns.Add((GridViewColumn)myresourcedictionary["gridDirFileSize"]);
           ListViewOp.View = grid
       }));
