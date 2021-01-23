    Public Class CleanNamesTextBox
        Inherits TextBox
     
        Private Class CleanNamesHtmlTextWriter
            Inherits HtmlTextWriter
     
            Sub New(writer As TextWriter)
                MyBase.New(writer)
            End Sub
     
            Public Overrides Sub AddAttribute(key As System.Web.UI.HtmlTextWriterAttribute, value As String)
                value = value.Split("$")(value.Split("$").Length - 1)
                MyBase.AddAttribute(key, value)
            End Sub
     
        End Class
     
        Protected Overrides Sub Render(writer As System.Web.UI.HtmlTextWriter)
            Dim noNamesWriter As CleanNamesHtmlTextWriter = New CleanNamesHtmlTextWriter(writer)
            MyBase.Render(noNamesWriter)
        End Sub
     
        Sub New(id As String, text As String, cssClass As String, clientIDMode As ClientIDMode)
            MyBase.New()
            Me.ID = id
            Me.CssClass = cssClass
            Me.ClientIDMode = clientIDMode
            Me.Text = text
        End Sub
     
    End Class
