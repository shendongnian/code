    Imports System.Linq
    
    Public Class QueueList(Of T)
        Inherits Queue(Of T)
        Implements IList(Of T)
    
        Public Sub Add(item As T) Implements ICollection(Of T).Add
            MyBase.Enqueue(item)
        End Sub
    
        Protected Sub Clear1() Implements ICollection(Of T).Clear
            MyBase.Clear()
        End Sub
    
        Protected Function Contains1(item As T) As Boolean Implements ICollection(Of T).Contains
            Return MyBase.Contains(item)
        End Function
    
        Protected Sub CopyTo1(array() As T, arrayIndex As Integer) Implements ICollection(Of T).CopyTo
            MyBase.CopyTo(array, arrayIndex)
        End Sub
    
        Protected ReadOnly Property Count1 As Integer Implements ICollection(Of T).Count
            Get
                Return MyBase.Count
            End Get
        End Property
    
        Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of T).IsReadOnly
            Get
                Return True
            End Get
        End Property
    
        Protected Function Remove(item As T) As Boolean Implements ICollection(Of T).Remove
            Throw New NotImplementedException
        End Function
    
        Public Function IndexOf(item As T) As Integer Implements IList(Of T).IndexOf
            Return Me.ToList.IndexOf(item)
        End Function
    
        Public Sub Insert(index As Integer, item As T) Implements IList(Of T).Insert
            Throw New NotImplementedException
        End Sub
    
        Default Public Property Item(index As Integer) As T Implements IList(Of T).Item
            Get
                Return Me.ToList.Item(index)
            End Get
            Set(value As T)
                Throw New NotImplementedException
            End Set
        End Property
    
        Public Sub RemoveAt(index As Integer) Implements IList(Of T).RemoveAt
            Throw New NotImplementedException
        End Sub
    End Class
