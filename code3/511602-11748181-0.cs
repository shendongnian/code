    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Control | Keys.C))
        {
            if (pic_display.Image != null)
            {
                MemoryStream stream = new MemoryStream())
                clipboardStatus.Text = "Copying image to clipboard...";
                pic_display.Image.Save(stream, ImageFormat.Png);
    
                clipboardThread = new Thread(copy_to_clipboard);
                clipboardThread.SetApartmentState(ApartmentState.STA);
                clipboardThread.Start(stream);
            }
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    
    private void copy_to_clipboard(object state)
    {
        var stream = (Stream) state;
        try
        {
            var data = new DataObject("PNG", stream);
            Clipboard.Clear();
            Clipboard.SetDataObject(data, true);
            BeginInvoke((MethodInvoker) (() => clipboardStatus.Text = "Copied successfully!"));
        }
        finally
        {
            stream.Dispose();
        }
    }
