    Public Class Form2
        Inherits Form
        Implements IForm
        Public Property IsDisposed1 As Boolean Implements IForm.IsDisposed
        Public Sub Show1() Implements IForm.Show
            Me.Show() ' Original method still exists and is accessible like this
        End Sub
    End Class
