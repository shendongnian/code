    Public Class pdfPageEvents
        Inherits iTextSharp.text.pdf.PdfPageEventHelper
        Private _strTitle As String, _strPrintFeatures As String
    
        Public Sub New(ByVal Title As String, ByVal PrintFeatures As String)
            _strTitle = Title
            _strPrintFeatures = PrintFeatures
        End Sub
    
        Public Overrides Sub OnStartPage(ByVal writer As PdfWriter, ByVal doc As Document)
            If InStr(_strPrintFeatures, "header") > 0 Then
                Dim fntFont As Font = FontFactory.GetFont("Tahoma", BaseFont.CP1250, True, 10, Font.NORMAL, New BaseColor(128, 128, 128))
                Dim imgImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("../LocalResources/Images/print_company_logo_medium.png"))
                Dim tblTable As New PdfPTable(2)
                Dim celRightCell As PdfPCell
    
                tblTable.WidthPercentage = 100
                tblTable.HorizontalAlignment = Element.ALIGN_CENTER
                imgImage.ScalePercent(70)
    
                Dim celLeftCell As New PdfPCell(New Phrase(_strTitle, fntFont))
                celLeftCell.HorizontalAlignment = Element.ALIGN_LEFT
                celLeftCell.Border = 0
                celLeftCell.BorderWidthBottom = 0.5
                celLeftCell.BorderColorBottom = New BaseColor(128, 128, 128)
                celLeftCell.VerticalAlignment = Element.ALIGN_BOTTOM
                celLeftCell.PaddingBottom = 3
                tblTable.AddCell(celLeftCell)
    
                If InStr(_strPrintFeatures, "logo") > 0 Then
                    celRightCell = New PdfPCell(imgImage)
                Else
                    celRightCell = New PdfPCell(New Paragraph(""))
                End If
    
                celRightCell.HorizontalAlignment = Element.ALIGN_RIGHT
                celRightCell.Border = 0
                celRightCell.BorderWidthBottom = 0.5
                celRightCell.BorderColorBottom = New BaseColor(128, 128, 128)
                celRightCell.VerticalAlignment = Element.ALIGN_BOTTOM
                celRightCell.PaddingBottom = 3
                tblTable.AddCell(celRightCell)
    
                doc.Add(tblTable)
                doc.Add(New Paragraph(vbNewLine))
            End If
        End Sub
    
        Public Overrides Sub OnEndPage(ByVal writer As PdfWriter, ByVal doc As Document)
            If InStr(_strPrintFeatures, "footer") > 0 Then
                Dim fntFont As Font = FontFactory.GetFont("Tahoma", BaseFont.CP1250, True, 10, Font.NORMAL, New BaseColor(128, 128, 128))
                Dim tblTable As New PdfPTable(2)
                Dim strDate As String = IIf(InStr(_strPrintFeatures, "date") > 0, FormatDateTime(Date.Today, DateFormat.GeneralDate), "")
    
                tblTable.TotalWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin
                tblTable.HorizontalAlignment = Element.ALIGN_CENTER
    
                Dim celLeftCell As New PdfPCell(New Phrase(strDate, fntFont))
                celLeftCell.HorizontalAlignment = Element.ALIGN_LEFT
                celLeftCell.Border = 0
                celLeftCell.BorderWidthTop = 0.5
                celLeftCell.BorderColorTop = New BaseColor(128, 128, 128)
                celLeftCell.VerticalAlignment = Element.ALIGN_BOTTOM
                tblTable.AddCell(celLeftCell)
    
                Dim celRightCell As New PdfPCell(New Phrase(CStr(doc.PageNumber), fntFont))
                celRightCell.HorizontalAlignment = Element.ALIGN_RIGHT
                celRightCell.Border = 0
                celRightCell.BorderWidthTop = 0.5
                celRightCell.BorderColorTop = New BaseColor(128, 128, 128)
                celRightCell.VerticalAlignment = Element.ALIGN_BOTTOM
                tblTable.AddCell(celRightCell)
                tblTable.WriteSelectedRows(0, -1, doc.LeftMargin, (doc.BottomMargin), writer.DirectContent)
            End If
        End Sub
    End Class
