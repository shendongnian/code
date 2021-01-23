    Imports System.ComponentModel
    
    Public Class Example
        Public Event Foo As EventHandler
    
        Public Property SynchronizingObject As ISynchronizeInvoke
    
        Protected Sub OnFoo(e As EventArgs)
            If SynchronizingObject IsNot Nothing AndAlso SynchronizingObject.InvokeRequired Then
                SynchronizingObject.BeginInvoke(Sub() RaiseEvent Foo(Me, e), Nothing)
            Else
                RaiseEvent Foo(Me, e)
            End If
        End Sub
    End Class
