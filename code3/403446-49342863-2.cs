    Imports System.Linq
    Imports System.ComponentModel
    Imports System.Collections.Specialized
    Imports System.Linq.Expressions
    
    Public Class ObservableConcurrentQueueList(Of T)
        Inherits ObservableConcurrentQueue(Of T)
        Implements IList(Of T), IBindingList
    
        Public Sub Clear()
            Dim item As T
            While (Not IsEmpty())
                MyBase.TryDequeue(item)
            End While
        End Sub
    
    #Region "IList Implementation"
    
        Public Sub Add1(item As T) Implements ICollection(Of T).Add
            MyBase.Enqueue(item)
        End Sub
    
        Protected Sub Clear1() Implements ICollection(Of T).Clear
            Clear()
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
    
        Protected ReadOnly Property IsReadOnly1 As Boolean Implements ICollection(Of T).IsReadOnly
            Get
                Return True
            End Get
        End Property
    
        Protected Function Remove1(item As T) As Boolean Implements ICollection(Of T).Remove
            Throw New NotImplementedException
        End Function
    
        Protected Function IndexOf1(item As T) As Integer Implements IList(Of T).IndexOf
            Return Me.ToList.IndexOf(item)
        End Function
    
        Protected Sub Insert1(index As Integer, item As T) Implements IList(Of T).Insert
            Throw New NotImplementedException
        End Sub
    
        Protected Property Item1(index As Integer) As T Implements IList(Of T).Item
            Get
                Return Me.ToList.Item(index)
            End Get
            Set(value As T)
                Throw New NotImplementedException
            End Set
        End Property
    
        Protected Sub RemoveAt1(index As Integer) Implements IList(Of T).RemoveAt
            Throw New NotImplementedException
        End Sub
    
    #End Region
    
    #Region "IBindList Implementation"
    
        Protected Function Add2(value As Object) As Integer Implements IList.Add
            'Throw New NotImplementedException
            MyBase.Enqueue(value)
            Return Nothing
        End Function
    
        Protected Sub Clear2() Implements IList.Clear
            Clear()
        End Sub
    
        Protected Function Contains2(value As Object) As Boolean Implements IList.Contains
            Return MyBase.Contains(value)
        End Function
    
        Protected Function IndexOf2(value As Object) As Integer Implements IList.IndexOf
            Return Me.ToList.IndexOf(value)
        End Function
    
        Protected Sub Insert2(index As Integer, value As Object) Implements IList.Insert
            Throw New NotImplementedException
        End Sub
    
        Protected ReadOnly Property IsFixedSize2 As Boolean Implements IList.IsFixedSize
            Get
                Return False
            End Get
        End Property
    
        Protected ReadOnly Property IsReadOnly2 As Boolean Implements IList.IsReadOnly
            Get
                Return True
            End Get
        End Property
    
        Protected Overloads Property Item2(index As Integer) As Object Implements IList.Item
            Get
                Return Me.ToList.Item(index)
            End Get
            Set(value As Object)
                Throw New NotImplementedException
            End Set
        End Property
    
        Protected Sub Remove2(value As Object) Implements IList.Remove
            Throw New NotImplementedException
        End Sub
    
        Protected Sub RemoveAt2(index As Integer) Implements IList.RemoveAt
            Throw New NotImplementedException
        End Sub
    
        Protected Sub AddIndex2([property] As PropertyDescriptor) Implements IBindingList.AddIndex
    
        End Sub
    
        Protected Function AddNew2() As Object Implements IBindingList.AddNew
            Throw New NotImplementedException
        End Function
    
        Protected ReadOnly Property AllowEdit2 As Boolean Implements IBindingList.AllowEdit
            Get
                Return False
            End Get
        End Property
    
        Protected ReadOnly Property AllowNew2 As Boolean Implements IBindingList.AllowNew
            Get
                Return False
            End Get
        End Property
    
        Protected ReadOnly Property AllowRemove2 As Boolean Implements IBindingList.AllowRemove
            Get
                Return False
            End Get
        End Property
    
        Protected Sub ApplySort2([property] As PropertyDescriptor, direction As ListSortDirection) Implements IBindingList.ApplySort
            Throw New NotImplementedException
        End Sub
    
        Protected Function Find2([property] As PropertyDescriptor, key As Object) As Integer Implements IBindingList.Find
            Throw New NotImplementedException
            Return Nothing
        End Function
    
        Protected ReadOnly Property IsSorted2 As Boolean Implements IBindingList.IsSorted
            Get
                Return False
            End Get
        End Property
    
        Protected Event ListChanged2(sender As Object, e As ListChangedEventArgs) Implements IBindingList.ListChanged
    
        Protected Sub RemoveIndex2([property] As PropertyDescriptor) Implements IBindingList.RemoveIndex
            Throw New NotImplementedException
        End Sub
    
        Protected Sub RemoveSort2() Implements IBindingList.RemoveSort
            'Throw New NotImplementedException
        End Sub
    
        Protected ReadOnly Property SortDirection2 As ListSortDirection Implements IBindingList.SortDirection
            Get
                'Throw New NotImplementedException
            End Get
        End Property
    
        Protected ReadOnly Property SortProperty2 As PropertyDescriptor Implements IBindingList.SortProperty
            Get
                Throw New NotImplementedException
                Return Nothing
            End Get
        End Property
    
        Protected ReadOnly Property SupportsChangeNotification2 As Boolean Implements IBindingList.SupportsChangeNotification
            Get
                Return True
            End Get
        End Property
    
        Protected ReadOnly Property SupportsSearching2 As Boolean Implements IBindingList.SupportsSearching
            Get
                Return False
            End Get
        End Property
    
        Protected ReadOnly Property SupportsSorting2 As Boolean Implements IBindingList.SupportsSorting
            Get
                Return False
            End Get
        End Property
    
    #End Region
    
    End Class
