    // Drag and Drop Files to Listbox
    private void listBox1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            e.Effect = DragDropEffects.All;
        else
            e.Effect = DragDropEffects.None;
    }
    private void listBox1_DragDrop(object sender, DragEventArgs e)
    {
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        foreach (string fileName in files)
        {
           listBox1.Items.Add(fileName);  
        }
    }
