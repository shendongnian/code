    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim strFileName As String = "Umzugsmitteilung.doc"
        Dim strUID As String = context.Request.QueryString("ump_uid")
        context.Response.Clear()
        'If String.IsNullOrEmpty(strUID) Or fileData Is Nothing Then
        '    context.Response.Write("<script type=""text/javascript"">alert('File does not exist !')</script>")
        '    context.Response.End()
        'End If
        context.Response.ClearContent()
        'context.Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName)
        context.Response.AddHeader("Content-Disposition", GetContentDisposition(strFileName))
        'context.Response.ContentType = "application/msword"
        context.Response.ContentType = "application/octet-stream"
        GetUmzugsMitteilung(strUID)
        context.Response.End()
    End Sub ' ProcessRequest
    Public Shared Sub SaveWordDocumentToOutputStream(strUID As String, doc As Aspose.Words.Document)
        Using ms As System.IO.MemoryStream = New System.IO.MemoryStream()
            CreateWordDocumentFromTemplate(strUID, doc, ms)
            ms.Position = 0
            Dim bytes As Byte() = New Byte(ms.Length - 1) {}
            ms.Read(bytes, 0, CInt(ms.Length))
            System.Web.HttpContext.Current.Response.OutputStream.Write(bytes, 0, ms.Length)
            ms.Close()
        End Using ' ms
    End Sub ' SaveWordDocumentToOutputStream
        Public Shared Function StripInvalidPathChars(str As String) As String
            If str Is Nothing Then
                Return Nothing
            End If
            Dim strReturnValue As String = ""
            Dim strInvalidPathChars As New String(System.IO.Path.GetInvalidPathChars())
            Dim bIsValid As Boolean = True
            For Each cThisChar As Char In str
                bIsValid = True
                For Each cInvalid As Char In strInvalidPathChars
                    If cThisChar = cInvalid Then
                        bIsValid = False
                        Exit For
                    End If
                Next cInvalid
                If bIsValid Then
                    strReturnValue += cThisChar
                End If
            Next cThisChar
            Return strReturnValue
        End Function ' StripInvalidPathChars
        Public Shared Function GetContentDisposition(ByVal strFileName As String) As String
            ' http://stackoverflow.com/questions/93551/how-to-encode-the-filename-parameter-of-content-disposition-header-in-http
            Dim contentDisposition As String
            strFileName = StripInvalidPathChars(strFileName)
            If System.Web.HttpContext.Current IsNot Nothing AndAlso System.Web.HttpContext.Current.Request.Browser IsNot Nothing Then
                If (System.Web.HttpContext.Current.Request.Browser.Browser = "IE" And (System.Web.HttpContext.Current.Request.Browser.Version = "7.0" Or System.Web.HttpContext.Current.Request.Browser.Version = "8.0")) Then
                    contentDisposition = "attachment; filename=" + Uri.EscapeDataString(strFileName).Replace("'", Uri.HexEscape("'"c))
                ElseIf (System.Web.HttpContext.Current.Request.Browser.Browser = "Safari") Then
                    contentDisposition = "attachment; filename=" + strFileName
                Else
                    contentDisposition = "attachment; filename*=UTF-8''" + Uri.EscapeDataString(strFileName)
                End If
            Else
                contentDisposition = "attachment; filename*=UTF-8''" + Uri.EscapeDataString(strFileName)
            End If
            Return contentDisposition
        End Function ' GetContentDisposition
