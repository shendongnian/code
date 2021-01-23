            private void FilesDropped(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
    
                    string[] droppedFilePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
    ...
