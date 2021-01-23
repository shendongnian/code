Dim content as string
If HttpContext.Current.Request.InputStream.CanSeek Then
    HttpContext.Current.Request.InputStream.Seek(0, IO.SeekOrigin.Begin)
End If
Using reader As New System.IO.StreamReader(HttpContext.Current.Request.InputStream)
    content = reader.ReadToEnd()
End Using
