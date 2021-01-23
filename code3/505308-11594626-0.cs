    Imports System.IO
    Imports HtmlAgilityPack
    
    Partial Class Default2
        Inherits System.Web.UI.Page
    
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
    
            Dim mem As New System.IO.MemoryStream()
            Dim twr As New System.IO.StreamWriter(mem)
            Dim myWriter As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(twr)
            MyBase.Render(myWriter)
    
            myWriter.Flush()
            myWriter.Dispose()
    
            Dim strmRdr As New System.IO.StreamReader(mem)
            strmRdr.BaseStream.Position = 0
            Dim pageContent As String = strmRdr.ReadToEnd()
            strmRdr.Dispose()
            mem.Dispose()
    
            writer.Write(AlterWithHTMLAGP(pageContent))
    
    
        End Sub
    
    
    
        Function AlterWithHTMLAGP(ByVal pageSource As String) As String
    
            Dim htmlDoc As HtmlDocument = New HtmlDocument()
    
            htmlDoc.OptionFixNestedTags = True
    
            htmlDoc.LoadHtml(pageSource)
    
            Dim newNode As HtmlNode = HtmlNode.CreateNode("<div>" & "someHtml" & "</div>")
    
            Dim body As HtmlNode = htmlDoc.DocumentNode.SelectSingleNode("//body")
    
            body.PrependChild(newNode)
    
    
            Return htmlDoc.DocumentNode.WriteTo()
    
        End Function
    
    
    End Class
