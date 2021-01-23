    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.All;
    }
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        string[] asFormats = e.Data.GetFormats();
        string[] asFileNames = (string[])e.Data.GetData("FileName");
    }
