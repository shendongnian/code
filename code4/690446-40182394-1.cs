    DataGrid grd = this.myGridName;
    grd.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
    ApplicationCommands.Copy.Execute(null, grd);
    grd.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
    //so that you can copy individual cell if you like or right click on grid   and copy with headers
     }
