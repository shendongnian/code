    Imports System.Collections.Concurrent
    Imports System.Collections.Specialized
    
    Public Class ObservableConcurrentQueue(Of T)
        Inherits ConcurrentQueue(Of T)
        Implements INotifyCollectionChanged
    
        Public Event CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs) Implements INotifyCollectionChanged.CollectionChanged
        Private Sub OnCollectionChanged(ByVal args As NotifyCollectionChangedEventArgs)
            RaiseEvent CollectionChanged(Me, args)
        End Sub
    
        Public Shadows Sub Enqueue(ByVal item As T)
            MyBase.Enqueue(item)
            OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item))
        End Sub
    
        Public Shadows Function TryDequeue(ByRef result As T) As Boolean
            If Not MyBase.TryDequeue(result) Then
                Return False
            End If
    
            OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, result))
    
            Return True
        End Function
    
    End Class
