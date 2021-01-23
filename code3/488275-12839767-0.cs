    Public Class IgnoreKeyboardCheckBox
        Inherits CheckBox
    
        Protected Overrides Sub OnKeyDown(e As System.Windows.Input.KeyEventArgs)
            If e.Key = Key.Space Then
                MyBase.OnKeyDown(e)
            End If
        End Sub
    End Class
