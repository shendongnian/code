    ''' <summary>
    ''' Copies an Bytearray into an image and return it.
    ''' </summary>
    ''' <param name="ArrSrc">Source byte array of image which can be anything</param>
    ''' <param name="ImageSize">the image size of the image</param>
    ''' <param name="SourceArrayPixelFormat">Pixel format, like 24Bit or 32Bit</param>
    ''' <returns>System.Drawing.Image</returns>
    ''' <remarks>copyright, http://software.goldengel.ch, 2012</remarks>
    Public Function ArrayToBitmapData(ByVal ArrSrc() As Byte, ByVal ImageSize As System.Drawing.Size, ByVal SourceArrayPixelFormat As System.Drawing.Imaging.PixelFormat) As System.Drawing.Bitmap
        'Kopiert ein ByteArray in ein Bitmap
    
        Dim m As Integer
        Dim bmTemp As System.Drawing.Bitmap = Nothing
        Dim S As System.Drawing.Size
        Dim MemorySize As Integer
        Dim ScanLine As Integer
    
        'Bild prüfen
        If ArrSrc Is Nothing Then Return bmTemp
    
        'Bildgrösse definieren
        'Bei unterschiedlichen Grössen, wird muss die kleinere Grösse verwendet werden
        S = ImageSize
    
    
        'Helfer für die Bildverarbeitung erzeugen
        Dim bts As System.Drawing.Imaging.BitmapData
    
        'Bitmap erzeugen um damit zu arbeiten
        bmTemp = New System.Drawing.Bitmap(S.Width, S.Height, SourceArrayPixelFormat)
    
        'Farbtiefe berechnen
        '24Bit und 32Bit Bilder werden unterstützt
        'Kann beliebig erweitert werden
        m = BytesInPixelFormat(SourceArrayPixelFormat)
    
    
    
        '*** Hauptroutine - Array --> Bitmap ***
    
        'Bilddaten in die Picturebox laden
        bts = bmTemp.LockBits(New System.Drawing.Rectangle(0, 0, S.Width, _
            S.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, SourceArrayPixelFormat)
    
    
        'Speicherplatz reservieren
        'MemorySize = S.Height * S.Width * m
        'Nur zur Kontrolle
        ScanLine = GetScanline(S, SourceArrayPixelFormat)
    
        MemorySize = S.Height * bts.Stride
        If ArrSrc.Length >= MemorySize Then
            'Bilddaten aus dem Array laden
            Global.System.Runtime.InteropServices.Marshal.Copy(ArrSrc, 0, bts.Scan0, MemorySize)
        End If
        bmTemp.UnlockBits(bts)
    
        'Erzeugtes Bitmap zurückgeben
        Return bmTemp
    
    End Function
    
    
    
    convert Bitmap image into byte array
    
    'Neue Funktion 27.2.2008
    'Mit korrekter Dimensionierung mittels bts.Stride und Umrechnung auf das Pixelformat
    ''' <summary>
    ''' Get an Array of the data of any image. 
    ''' Bitmap header execluded.
    ''' </summary>
    ''' <param name="bmSrc">Source image</param>
    ''' <param name="NeededDestinationPixelFormat">Pixelformat, like 24Bit or 32Bit</param>
    ''' <returns>Image content</returns>
    ''' <remarks>copyright http://software.goldengel.ch, 2012</remarks>
    Public Function BitmapDataToArray(ByVal bmSrc As System.Drawing.Bitmap, ByVal NeededDestinationPixelFormat As System.Drawing.Imaging.PixelFormat, ByRef DstStride As Integer) As Byte()
        'Kopiert ein Bild in ein Bytearray
    
        Dim m As Integer
        Dim A() As Byte = Nothing
        Dim S As System.Drawing.Size
        Dim MemorySize As Integer
        Dim bmTemp As System.Drawing.Bitmap = Nothing
    
        'Bild prüfen
        If bmSrc Is Nothing Then Return A
    
        'Bildgrösse definieren
        'Bei unterschiedlichen Grössen, wird muss die kleinere Grösse verwendet werden
        S = bmSrc.Size
    
    
        'Helfer für die Bildverarbeitung erzeugen
        Dim bts As System.Drawing.Imaging.BitmapData
    
        'Farbtiefe berechnen
        '24Bit und 32Bit Bilder werden unterstützt
        'Kann beliebig erweitert werden
        m = BytesInPixelFormat(NeededDestinationPixelFormat)
    
    
        '*** Hauptroutine - Bitmap --> Array ***
        'Bilddaten aus der Picturebox laden
        If NeededDestinationPixelFormat <> bmSrc.PixelFormat Then
            'Bitmap erzeugen um damit zu arbeiten
            bmTemp = New System.Drawing.Bitmap(S.Width, S.Height, NeededDestinationPixelFormat)
    
            Using gr As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(bmTemp)
                gr.DrawImage(bmSrc, 0, 0)
            End Using
            'ImgSrc.Dispose()'Achtung, würde das Original mit zerstören
            bmSrc = bmTemp
        End If
    
        bts = bmSrc.LockBits(New System.Drawing.Rectangle(0, 0, S.Width, _
            S.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, NeededDestinationPixelFormat)
    
        'Speicherplatz reservieren
        MemorySize = S.Height * bts.Stride
        ReDim A(MemorySize - 1) '28.2.2010. wichtige Änderung. 1 Byte zuviel wurde reserviert. Das konnte bei Wiederholung von Graphics.Drawing zu einem Fehler kommen
    
        'Bitmapdaten in das Array kopieren
        Global.System.Runtime.InteropServices.Marshal.Copy(bts.Scan0, A, 0, A.Length)
        bmSrc.UnlockBits(bts)
    
        DstStride = bts.Stride
    
        If bmTemp IsNot Nothing Then bmTemp = Nothing
    
        Return A
    
    End Function
