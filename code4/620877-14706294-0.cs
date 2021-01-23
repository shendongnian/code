    Public Function CreatePDF(images As System.Collections.Generic.List(Of Byte())) As String
            Dim PDFGeneratePath = Server.MapPath("../images/pdfimages/")
            Dim FileName = "attachmentpdf-" & DateTime.Now.Ticks & ".pdf"
    
            If images.Count >= 1 Then
                Dim document As New Document(PageSize.LETTER)
                Try
                    ' Create pdfimages directory in images folder.
                    If (Not Directory.Exists(PDFGeneratePath)) Then
                        Directory.CreateDirectory(PDFGeneratePath)
                    End If
    
                    ' we create a writer that listens to the document
                    ' and directs a PDF-stream to a file
                    PdfWriter.GetInstance(document, New FileStream(PDFGeneratePath & FileName, FileMode.Create))
    
                    ' opens up the document
                    document.Open()
                    ' Add metadata to the document.  This information is visible when viewing the
    
                    ' Set images in table
                    Dim imageTable As New PdfPTable(2)
                    imageTable.DefaultCell.Border = Rectangle.NO_BORDER
                    imageTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
    
                    For ImageIndex As Integer = 0 To images.Count - 1
                        If (images(ImageIndex) IsNot Nothing) AndAlso (images(ImageIndex).Length > 0) Then
                            Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(SRS.Utility.Utils.ByteArrayToImage(images(ImageIndex)), System.Drawing.Imaging.ImageFormat.Jpeg)
    
                            ' Setting image resolution
                            If pic.Height > pic.Width Then
                                Dim percentage As Single = 0.0F
                                percentage = 400 / pic.Height
                                pic.ScalePercent(percentage * 100)
                            Else
                                Dim percentage As Single = 0.0F
                                percentage = 240 / pic.Width
                                pic.ScalePercent(percentage * 100)
                            End If
    
                            pic.Border = iTextSharp.text.Rectangle.BOX
                            pic.BorderColor = iTextSharp.text.BaseColor.BLACK
                            pic.BorderWidth = 3.0F
    
                            imageTable.AddCell(pic)
                        End If
                        If ((ImageIndex + 1) Mod 6 = 0) Then
                            document.Add(imageTable)
                            document.NewPage()
    
                            imageTable = New PdfPTable(2)
                            imageTable.DefaultCell.Border = Rectangle.NO_BORDER
                            imageTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
                        End If
                        If (ImageIndex = (images.Count - 1)) Then
                            imageTable.AddCell(String.Empty)
                            document.Add(imageTable)
                            document.NewPage()
                        End If
                    Next
                Catch ex As Exception
                    Throw ex
                Finally
                    ' Close the document object
                    ' Clean up
                    document.Close()
                    document = Nothing
                End Try
            End If
    
            Return PDFGeneratePath & FileName
        End Function
