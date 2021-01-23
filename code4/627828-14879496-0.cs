    Private Sub uiPdf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles uiPdf.Click
        Dim urlToConvert As String = "ExportPdf.aspx"
        '// get the html string for the report
        Dim htmlStringWriter As New System.IO.StringWriter()
        Server.Execute(urlToConvert, htmlStringWriter)
        Dim htmlCodeToConvert As String = htmlStringWriter.GetStringBuilder().ToString()
        htmlStringWriter.Close()
        '// Create the PDF converter. 
        Dim pdfConverter As New EvoPdf.HtmlToPdf.PdfConverter()
        '************
        'Add the cookie so we don't get bounced to the home page
        '************ 
        If Not Request.Cookies(System.Web.Security.FormsAuthentication.FormsCookieName) Is Nothing Then
            pdfConverter.HttpRequestCookies.Add(System.Web.Security.FormsAuthentication.FormsCookieName, Request.Cookies(System.Web.Security.FormsAuthentication.FormsCookieName).Value)
        End If
        '// set the license key - required
        pdfConverter.LicenseKey = ConfigurationManager.AppSettings("EvoPdfLicenseKey")
        '// set the converter options - optional
        '... code omitted
        '// be saved to a file or sent as a browser response
        Dim baseUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim pdfBytes As Byte() = pdfConverter.GetPdfBytesFromHtmlString(htmlCodeToConvert, baseUrl)
        '// send the PDF document as a response to the browser for download
        Dim response As System.Web.HttpResponse = System.Web.HttpContext.Current.Response
        Response.Clear()
        Response.AddHeader("Content-Type", "application/pdf")
        response.AddHeader("Content-Disposition", String.Format("attachment; filename=GettingStarted.pdf; size={0}", pdfBytes.Length.ToString()))
        response.BinaryWrite(pdfBytes)
        response.End()
    End Sub
