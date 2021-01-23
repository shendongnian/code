     void FileBoard_Drop(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                FileInfo[] files = e.Data.GetData(DataFormats.FileDrop) as FileInfo[];
               
                foreach (FileInfo fi in files)
                {
                    _files.Enqueue(fi);
                }
            
            }
        }
