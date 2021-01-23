    private void Label_DragDrop(object sender, DragEventArgs e) {
        if (e.Data.GetDataPresent(typeof(Bitmap))) {
            ((Label)sender).Image = (Image)e.Data.GetData(DataFormats.Bitmap);
        }
    }
