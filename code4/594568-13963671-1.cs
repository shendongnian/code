    Public g_RowSizeBytes As Integer
    Public g_PixBytes() As Byte
    
    Private m_BitmapData As BitmapData
    
    ' Lock the bitmap's data.
    Public Sub LockBitmap(ByVal bm As Bitmap)
        ' Lock the bitmap data.
        Dim bounds As Rectangle = New Rectangle( _
            0, 0, bm.Width, bm.Height)
        m_BitmapData = bm.LockBits(bounds, _
            Imaging.ImageLockMode.ReadWrite, _
            Imaging.PixelFormat.Format24bppRgb)
        g_RowSizeBytes = m_BitmapData.Stride
    
        ' Allocate room for the data.
        Dim total_size As Integer = m_BitmapData.Stride * _
            m_BitmapData.Height
        ReDim g_PixBytes(total_size)
    
        ' Copy the data into the g_PixBytes array.
        Marshal.Copy(m_BitmapData.Scan0, g_PixBytes, _
            0, total_size)
    End Sub
