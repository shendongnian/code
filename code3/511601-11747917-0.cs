    protected Thread clipboardThread;
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
    if (keyData == (Keys.Control | Keys.C))
    {
        if (clipBoardThread == null)
        {
           clipboardThread = new Thread(copy_to_clipboard);
           clipboardThread.SetApartmentState(ApartmentState.STA);
           clipboardThread.IsBackGround = false;
        }
        if (!clipboardThread.IsAlive)
        {
           clipboardThread.Start();
        }
        return true;
    }
    return base.ProcessCmdKey(ref msg, keyData);
    }
    private void copy_to_clipboard()
    {
    if (pic_display.Image != null)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            clipboardStatus.Text = "Copying image to clipboard...";
            pic_display.Image.Save(stream, ImageFormat.Png);
            var data = new DataObject("PNG", stream);
            Clipboard.Clear();
            Clipboard.SetDataObject(data, true);
            clipboardStatus.Text = "Copied successfully!";
        }
    }
    }
</pre>
