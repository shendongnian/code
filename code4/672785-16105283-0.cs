    Public Class Form1
        Inherits Form
        Implements IForm
        Public Shadows Property IsDisposed As Boolean Implements IForm.IsDisposed
        Public Shadows Sub Show() Implements IForm.Show
            ' replaces original method in Form class
        End Sub
    End Class
