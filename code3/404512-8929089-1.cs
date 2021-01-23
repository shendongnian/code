    void Form1_DragDrop(object sender, DragEventArgs e) {
        object data = e.Data.GetData(DataFormats.FileDrop);
    }
    void Form1_DragEnter(object sender, DragEventArgs e) {
        if(e.Data.GetDataPresent(DataFormats.FileDrop)) {
            e.Effect = DragDropEffects.Copy;
        }
    }
