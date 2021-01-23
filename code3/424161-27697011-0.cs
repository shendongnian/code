    private void TextBox_PreviewDragEnter(object sender, DragEventArgs e)
    {
        e.Effects = DragDropEffects.Copy;
        e.Handled = true;
    }
    private void TextBox_PreviewDrop(object sender, DragEventArgs e)
    {
        object text = e.Data.GetData(DataFormats.FileDrop);
        TextBox tb = sender as TextBox;
        if (tb != null)
        {
            tb.Text = string.Format("{0}", ((string[])text)[0]);
        }
    }
