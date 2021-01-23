    MyRange.CopyPicture(Microsoft.Office.Interop.Excel.XlPictureAppearance.xlScreen,Microsoft.Office.Interop.Excel.XlCopyPictureFormat.xlBitmap)
    If Clipboard.GetDataObject IsNot Nothing Then
       Dim Data As IDataObject = Clipboard.GetDataObject
       If Data.GetDataPresent(DataFormats.Bitmap) Then
           Dim img As Image = Data.GetData(DataFormats.Bitmap, True)
           PictureBox1.Height = img.Height
           PictureBox1.Width = img.Width
           PictureBox1.Image = img
       End If
    End If
