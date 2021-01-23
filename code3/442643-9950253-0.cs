    private void MainForm_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            Array fileNames = (Array)e.Data.GetData(DataFormats.FileDrop);
            if (fileNames != null && fileNames.OfType<string>().Any())
            {
                foreach (var fileName in fileNames.OfType<string>())
                {
                    this.BeginInvoke(new Action<string>(this.AttemptOpenFromPath), fileName);
                }
            }
        }
    }
