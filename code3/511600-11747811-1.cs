    private void copy_to_clipboard()
    {
        using (var stream = new MemoryStream())
        {
            clipboardStatus.Text = "Copying image to clipboard...";
            pic_display.Invoke((Action)()=> { 
                if (pic_display.Image != null)
                  pic_display.Image.Save(stream, ImageFormat.Png); 
            });
            if (stream.Position == 0) return; // No image was saved
            var data = new DataObject("PNG", stream);
            Clipboard.Clear();
            Clipboard.SetDataObject(data, true);
            clipboardStatus.Text = "Copied successfully!";
        }
    }
