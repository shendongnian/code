    Public Class UserControl1
        Public Sub New()
            '' This call is required by the Windows Form Designer.
            InitializeComponent()
            '' Add any initialization after the InitializeComponent() call.
            MyToolstrip.Renderer = New ToolStripProfessionalRenderer(New MyInheretedProColorTable)
        End Sub
    End Class
