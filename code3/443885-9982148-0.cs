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
