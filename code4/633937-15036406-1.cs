    Public Class Form1
        Private WithEvents obj As Example
    
        Public Sub New()
            InitializeComponent()
            obj.SynchronizingObject = Me
        End Sub
    
        Private Sub obj_Foo(sender As Object, e As EventArgs) Handles obj.Foo
            '' No marshaling required
            ''...
        End Sub
    End Class
