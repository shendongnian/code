    Using ms As New System.IO.MemoryStream()
    Using doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4)
    Using w As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, ms)
    
    Dim FileName As String = "Name.pdf"
    
    
    Here create your document end close it
    
    Response.Clear()
    Response.ContentType = "application/octet-stream"
    Response.AddHeader("content-disposition", "attachment;filename= " & FileName)
    Response.Buffer = True
    Response.Clear()
    Dim bytes = ms.ToArray()
    Response.OutputStream.Write(bytes, 0, bytes.Length)
    Response.OutputStream.Flush()
    
    
    End Using
    End Using
    End Using
