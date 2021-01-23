    Imports HtmlAgilityPack
    
    Public Class _Default
        Inherits System.Web.UI.Page
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim webGet As HtmlWeb = New HtmlWeb
            Dim htmlDoc As HtmlDocument = webGet.Load("http://stackoverflow.com/q/11528387/1350308")
    
            Dim ids As New List(Of String)()
            TextBox1.Text = ""
            For Each div As HtmlNode In htmlDoc.DocumentNode.SelectNodes("//div")
                TextBox1.Text += div.Id + Environment.NewLine
            Next
        End Sub
    
    End Class
