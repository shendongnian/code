    Private Shared Function ExtractImages(ByVal pdf As Byte()) As List(Of Byte())
        Dim images As New List(Of Byte())
        Dim reader As New PdfReader(pdf)
        If (reader IsNot Nothing) Then
            ' Loop through all of the references in the PDF.
            For refIndex = 0 To (reader.XrefSize - 1)
                ' Get the object.
                Dim obj = reader.GetPdfObject(refIndex)
                ' Make sure we have something and that it is a stream.
                If (obj IsNot Nothing) AndAlso obj.IsStream() Then
                    ' Cast it to a dictionary object.
                    Dim pdfDict = DirectCast(obj, iTextSharp.text.pdf.PdfDictionary)
                    ' See if it has a subtype property that is set to /IMAGE.
                    If pdfDict.Contains(iTextSharp.text.pdf.PdfName.SUBTYPE) AndAlso (pdfDict.Get(iTextSharp.text.pdf.PdfName.SUBTYPE).ToString() = iTextSharp.text.pdf.PdfName.IMAGE.ToString()) Then
                        ' Grab various properties of the image.
                        Dim filter = pdfDict.Get(iTextSharp.text.pdf.PdfName.FILTER).ToString()
                        Dim width = pdfDict.Get(iTextSharp.text.pdf.PdfName.WIDTH).ToString()
                        Dim height = pdfDict.Get(iTextSharp.text.pdf.PdfName.HEIGHT).ToString()
                        Dim bpp = pdfDict.Get(iTextSharp.text.pdf.PdfName.BITSPERCOMPONENT).ToString()
                        ' Grab the raw bytes of the image
                        Dim bytes = PdfReader.GetStreamBytesRaw(DirectCast(obj, PRStream))
                        ' Images can be encoded in various ways. 
                        ' All of our images are encoded with a single filter.
                        ' If there is a need to decode another filter, it will need to be added.
                        If (filter = iTextSharp.text.pdf.PdfName.CCITTFAXDECODE.ToString()) Then
                            Using ms = New MemoryStream()
                                Using tiff As Tiff = tiff.ClientOpen("memory", "w", ms, New TiffStream())
                                    tiff.SetField(TiffTag.IMAGEWIDTH, width)
                                    tiff.SetField(TiffTag.IMAGELENGTH, height)
                                    tiff.SetField(TiffTag.COMPRESSION, Compression.CCITTFAX4)
                                    tiff.SetField(TiffTag.BITSPERSAMPLE, bpp)
                                    tiff.SetField(TiffTag.SAMPLESPERPIXEL, 1)
                                    tiff.WriteRawStrip(0, bytes, bytes.Length)
                                    tiff.Flush()
                                    images.Add(ms.ToArray())
                                    tiff.Close()
                                End Using
                            End Using
                        Else
                            Throw New NotImplementedException("Decoding this filter has not been implemented")
                        End If
                    End If
                End If
            Next
        End If
        Return images
    End Function
