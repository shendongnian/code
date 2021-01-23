    PictureEditViewInfo viewInfo = GetViewInfo(originalPictureEdit);
    Rectangle cropRect = new Rectangle(
        _selection.X - viewInfo.PictureStartX,
        _selection.Y - viewInfo.PictureStartY,
        _selection.Width,
        _selection.Height);
    _croppedImage = (originalPictureEdit.Image as Bitmap).Clone(cropRect,
        originalPictureEdit.Image.PixelFormat);
    //...
    static PictureEditViewInfo GetViewInfo(PictureEdit edit) {
        PropertyInfo pInfo = typeof(BaseEdit).GetProperty("ViewInfo",
            BindingFlags.Instance | BindingFlags.NonPublic);
        return (PictureEditViewInfo)pInfo.GetValue(edit, new object[] { });
    }
