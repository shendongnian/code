    void MainFormDragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.StringFormat)) 
            e.Effect = DragDropEffects.Copy;
    }
    void MainFormDragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.StringFormat)) {
            string dropText = (string)e.Data.GetData(DataFormats.StringFormat);
            Debug.WriteLine(dropText);
        }
			
    }
