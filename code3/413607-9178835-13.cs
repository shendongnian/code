    Public Class TextToolStripSeparator
        Inherits ToolStripMenuItem
        Public Overrides ReadOnly Property CanSelect() As Boolean
            Get
                Return DesignMode
            End Get
        End Property
        Public Overrides ReadOnly Property HasDropDownItems() As Boolean
            Get
                Return False
            End Get
        End Property
    End Class
