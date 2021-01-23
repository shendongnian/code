    private void VideoCanvas_Drop(object sender, Microsoft.Windows.DragEventArgs e)
            {
                DragEventArgs dr = e as DragEventArgs;
    
                if (dr.Data == null)
                    return;
                IDataObject data = dr.Data;
                FileInfo[] file = data.GetData(DataFormats.FileDrop) as FileInfo[];
                if (file.Count() > 0)
                    mediaEl.SetSource(file[0].OpenRead());
                if (mediaEl.CurrentState != MediaElementState.Playing)
                {
                    mediaEl.Play();
                }
            }
