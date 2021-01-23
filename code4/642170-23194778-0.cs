        Dim pDoc As New Document(pRec)
        Dim pWriter As PdfWriter
        Response.AddHeader("Content-Disposition", "attachment;filename=" & Title & " .pdf")
        pWriter = PdfWriter.GetInstance(pDoc, Response.OutputStream)
        pRec.Border = 1
        pRec.BorderColor = BaseColor.MAGENTA
        pDoc.Open()
        'Add pdf Detail
        pDoc.AddTitle("REPORTS")
        pDoc.AddSubject(Title)
        pDoc.AddAuthor("ADMIN")
        pDoc.AddHeader("Company", "DK LTD")
        pDoc.AddHeader("PageSize", DocSize)
