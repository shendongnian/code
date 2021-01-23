    // Displays an ellipsis (...) button to start a modal dialog box
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    {
        return UITypeEditorEditStyle.Modal;
    }
    // Edits the value of the specified object using the editor style indicated by the GetEditStyle method.
    public override object EditValue(ITypeDescriptorContext context,
                                     IServiceProvider provider,
                                     object value)
    {
        // Show the dialog we use to open the file.
        // You could use a custom one at this point to provide the file path and the image.
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Image files (*.bmp | *.bmp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                bitmap.SetPath(openFileDialog.FileName);
                return bitmap;
            }
        }
        return value;
    }
    // Indicates whether the specified context supports painting
    // a representation of an object's value within the specified context.
    public override bool GetPaintValueSupported(ITypeDescriptorContext context)
    {
        return true;
    }
    // Paints a representation of the value of an object using the specified PaintValueEventArgs.
    public override void PaintValue(PaintValueEventArgs e)
    {
        if (e.Value != null)
        {
            // Get image
            Bitmap bmp = (Bitmap)e.Value;
            // This rectangle indicates the area of the Properties window to draw a representation of the value within.
            Rectangle destRect = e.Bounds;
            // Optional to set the default transparent color transparent for this image.
            bmp.MakeTransparent();
            // Draw image
            e.Graphics.DrawImage(bmp, destRect);
        }
    }
