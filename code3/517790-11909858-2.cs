    private void richTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
    {
        var richTextBox = (RichTextBox) sender;
        richTextBox.Width = e.NewRectangle.Width;
        richTextBox.Height = e.NewRectangle.Height;
    }
