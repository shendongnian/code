    private void DataGrid_DragOver(object sender, DragEventArgs e)
    {
        // check if the element dragged over is one or more files
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            // if so, show a link cursor
            e.Effects = DragDropEffects.Link;
        }
        else
        {
            // otherwise show a "block" cursor
            e.Effects = DragDropEffects.None;
        }
            
        // IMPORTANT: mark the event as "handled by us", to apply the drag effects
        e.Handled = true;
    }
    private void DataGrid_Drop(object sender, DragEventArgs e)
    {
        // Check if the data dropped is one or more files
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            // get the file pathes from the data object
            string[] filePaths = (e.Data.GetData(DataFormats.FileDrop) as string[]); 
            // do something with the pathes
            /* ... */
        }
    }
