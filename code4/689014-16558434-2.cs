    Imports System.Web
    Imports System.Web.Services
    
    Public Class TextHandler
        Implements System.Web.IHttpHandler
    
        Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
    
            'context.Response.ContentType = "text/plain"
            'context.Response.Write("Hello World!")
    
    
            Dim memoryStream As New System.IO.MemoryStream()
            Dim textWriter As System.IO.TextWriter = New System.IO.StreamWriter(memoryStream)
            textWriter.WriteLine("Something")
            textWriter.Flush()
    
            memoryStream.Position = 0
            Dim bytesInStream As Byte() = New Byte(memoryStream.Length - 1) {}
            'memoryStream.Write(bytesInStream, 0, bytesInStream.Length)
            memoryStream.Read(bytesInStream, 0, CInt(memoryStream.Length))
    
            memoryStream.Close()
            context.Response.Clear()
            context.Response.ContentType = "application/force-download"
            context.Response.AddHeader("content-disposition", "attachment; filename=name_you_file.txt")
            context.Response.BinaryWrite(bytesInStream)
            context.Response.End()
        End Sub
    
        ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property
    
    End Class
