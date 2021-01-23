    Public Class TextToolStripSeparator
        Inherits ToolStripMenuItem
        Public Overrides ReadOnly Property CanSelect() As Boolean
            Get
                Return DesignMode
            End Get
        End Property
    End Class
