    Public Class MenuStripEx
        Inherits MenuStrip
        
        Public Sub New()
            Me.Renderer = New ToolStripRendererEx()
        End Sub
        Private Class ToolStripRendererEx
            Inherits ToolStripProfessionalRenderer
            
            Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
                Const  flags As TextFormatFlags = TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter
                Dim item As ToolStripItem = e.Item
                If TypeOf item Is TextToolStripSeparator Then
                    Dim textWidth As Integer = TextRenderer.MeasureText(item.Text, item.Font).Width
                    Dim rect As Rectangle = e.TextRectangle
                    rect.Width = e.ToolStrip.Width - rect.Left - 3
                    TextRenderer.DrawText(e.Graphics, item.Text, item.Font, rect, Color.DimGray, flags)
                    Dim y As Integer = rect.Y + rect.Height \ 2
                    Dim margin As Integer = (rect.Width - textWidth) \ 2
                    e.Graphics.DrawLine(Pens.DarkGray, rect.X, y, rect.X + margin, y)
                    e.Graphics.DrawLine(Pens.DarkGray, rect.Right - margin, y, rect.Right, y)
                Else
                    MyBase.OnRenderItemText(e)
                End If
            End Sub
        End Class
    End Class
