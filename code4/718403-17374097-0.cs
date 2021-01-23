    string shapeName = "";
    for (int i = 0; i < sheet.Shapes.Count;i++ )
    {
       Microsoft.Office.Interop.Excel.Shape shape=sheet.Shapes.Item(i);
       if (shape.Type == MsoShapeType.msoPicture)
       {
          shapeName = shape.Name;
       }
    }
    Worksheet sheet = GetFirstSheet();
    if (sheet != null)
    {                    
        Picture pict = sheet.Pictures(shapeName ) as Picture;
        pict.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap);                 
    }
    if (Clipboard.ContainsImage())
    {
       Image img=Clipboard.GetImage();
       pbPicture.Image = img;
    }
