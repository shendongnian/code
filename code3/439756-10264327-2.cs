    Imports System.Collections
    Imports System.Collections.Specialized
    Imports System.Linq
    Imports System.Windows
    
    ''' <summary>
    ''' Keeps two lists synchronized. 
    ''' </summary>
    Public Class TwoListSynchronizer
        Implements IWeakEventListener
    
        Private Shared ReadOnly DefaultConverter As IListItemConverter = New DoNothingListItemConverter()
        Private ReadOnly _masterList As IList
        Private ReadOnly _masterTargetConverter As IListItemConverter
        Private ReadOnly _targetList As IList
    
    
        ''' <summary>
        ''' Initializes a new instance of the <see cref="TwoListSynchronizer"/> class.
        ''' </summary>
        ''' <param name="masterList">The master list.</param>
        ''' <param name="targetList">The target list.</param>
        ''' <param name="masterTargetConverter">The master-target converter.</param>
        Public Sub New(ByVal masterList As IList, ByVal targetList As IList, ByVal masterTargetConverter As IListItemConverter)
            _masterList = masterList
            _targetList = targetList
            _masterTargetConverter = masterTargetConverter
        End Sub
    
        ''' <summary>
        ''' Initializes a new instance of the <see cref="TwoListSynchronizer"/> class.
        ''' </summary>
        ''' <param name="masterList">The master list.</param>
        ''' <param name="targetList">The target list.</param>
        Public Sub New(ByVal masterList As IList, ByVal targetList As IList)
            Me.New(masterList, targetList, DefaultConverter)
        End Sub
    
        Private Delegate Sub ChangeListAction(ByVal list As IList, ByVal e As NotifyCollectionChangedEventArgs, ByVal converter As Converter(Of Object, Object))
    
        ''' <summary>
        ''' Starts synchronizing the lists.
        ''' </summary>
        Public Sub StartSynchronizing()
            ListenForChangeEvents(_masterList)
            ListenForChangeEvents(_targetList)
    
            ' Update the Target list from the Master list
            SetListValuesFromSource(_masterList, _targetList, AddressOf ConvertFromMasterToTarget)
    
            ' In some cases the target list might have its own view on which items should included:
            ' so update the master list from the target list
            ' (This is the case with a ListBox SelectedItems collection: only items from the ItemsSource can be included in SelectedItems)
            If Not TargetAndMasterCollectionsAreEqual() Then
                SetListValuesFromSource(_targetList, _masterList, AddressOf ConvertFromTargetToMaster)
            End If
        End Sub
    
        ''' <summary>
        ''' Stop synchronizing the lists.
        ''' </summary>
        Public Sub StopSynchronizing()
            StopListeningForChangeEvents(_masterList)
            StopListeningForChangeEvents(_targetList)
        End Sub
    
        ''' <summary>
        ''' Receives events from the centralized event manager.
        ''' </summary>
        ''' <param name="managerType">The type of the <see cref="T:System.Windows.WeakEventManager"/> calling this method.</param>
        ''' <param name="sender">Object that originated the event.</param>
        ''' <param name="e">Event data.</param>
        ''' <returns>
        ''' true if the listener handled the event. It is considered an error by the <see cref="T:System.Windows.WeakEventManager"/> handling in WPF to register a listener for an event that the listener does not handle. Regardless, the method should return false if it receives an event that it does not recognize or handle.
        ''' </returns>
        Public Function ReceiveWeakEvent(ByVal managerType As Type, ByVal sender As Object, ByVal e As EventArgs) As Boolean Implements System.Windows.IWeakEventListener.ReceiveWeakEvent
            HandleCollectionChanged(TryCast(sender, IList), TryCast(e, NotifyCollectionChangedEventArgs))
    
            Return True
        End Function
    
        ''' <summary>
        ''' Listens for change events on a list.
        ''' </summary>
        ''' <param name="list">The list to listen to.</param>
        Protected Sub ListenForChangeEvents(ByVal list As IList)
            If TypeOf list Is INotifyCollectionChanged Then
                CollectionChangedEventManager.AddListener(TryCast(list, INotifyCollectionChanged), Me)
            End If
        End Sub
    
        ''' <summary>
        ''' Stops listening for change events.
        ''' </summary>
        ''' <param name="list">The list to stop listening to.</param>
        Protected Sub StopListeningForChangeEvents(ByVal list As IList)
            If TypeOf list Is INotifyCollectionChanged Then
                CollectionChangedEventManager.RemoveListener(TryCast(list, INotifyCollectionChanged), Me)
            End If
        End Sub
    
        Private Sub AddItems(ByVal list As IList, ByVal e As NotifyCollectionChangedEventArgs, ByVal converter As Converter(Of Object, Object))
            Dim itemCount As Integer = e.NewItems.Count
    
            For i As Integer = 0 To itemCount - 1
                Dim insertionPoint As Integer = e.NewStartingIndex + i
    
                If insertionPoint > list.Count Then
                    list.Add(converter(e.NewItems(i)))
                Else
                    list.Insert(insertionPoint, converter(e.NewItems(i)))
                End If
            Next
        End Sub
    
        Private Function ConvertFromMasterToTarget(ByVal masterListItem As Object) As Object
            Return If(_masterTargetConverter Is Nothing, masterListItem, _masterTargetConverter.Convert(masterListItem))
        End Function
    
        Private Function ConvertFromTargetToMaster(ByVal targetListItem As Object) As Object
            Return If(_masterTargetConverter Is Nothing, targetListItem, _masterTargetConverter.ConvertBack(targetListItem))
        End Function
    
        Private Sub HandleCollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            Dim sourceList As IList = TryCast(sender, IList)
    
            Select Case e.Action
                Case NotifyCollectionChangedAction.Add
                    PerformActionOnAllLists(AddressOf AddItems, sourceList, e)
                    Exit Select
                Case NotifyCollectionChangedAction.Move
                    PerformActionOnAllLists(AddressOf MoveItems, sourceList, e)
                    Exit Select
                Case NotifyCollectionChangedAction.Remove
                    PerformActionOnAllLists(AddressOf RemoveItems, sourceList, e)
                    Exit Select
                Case NotifyCollectionChangedAction.Replace
                    PerformActionOnAllLists(AddressOf ReplaceItems, sourceList, e)
                    Exit Select
                Case NotifyCollectionChangedAction.Reset
                    UpdateListsFromSource(TryCast(sender, IList))
                    Exit Select
                Case Else
                    Exit Select
            End Select
        End Sub
    
        Private Sub MoveItems(ByVal list As IList, ByVal e As NotifyCollectionChangedEventArgs, ByVal converter As Converter(Of Object, Object))
            RemoveItems(list, e, converter)
            AddItems(list, e, converter)
        End Sub
    
        Private Sub PerformActionOnAllLists(ByVal action As ChangeListAction, ByVal sourceList As IList, ByVal collectionChangedArgs As NotifyCollectionChangedEventArgs)
            If sourceList Is _masterList Then
                PerformActionOnList(_targetList, action, collectionChangedArgs, AddressOf ConvertFromMasterToTarget)
            Else
                PerformActionOnList(_masterList, action, collectionChangedArgs, AddressOf ConvertFromTargetToMaster)
            End If
        End Sub
    
        Private Sub PerformActionOnList(ByVal list As IList, ByVal action As ChangeListAction, ByVal collectionChangedArgs As NotifyCollectionChangedEventArgs, ByVal converter As Converter(Of Object, Object))
            StopListeningForChangeEvents(list)
            action(list, collectionChangedArgs, converter)
            ListenForChangeEvents(list)
        End Sub
    
        Private Sub RemoveItems(ByVal list As IList, ByVal e As NotifyCollectionChangedEventArgs, ByVal converter As Converter(Of Object, Object))
            Dim itemCount As Integer = e.OldItems.Count
    
            ' for the number of items being removed, remove the item from the Old Starting Index
            ' (this will cause following items to be shifted down to fill the hole).
            For i As Integer = 0 To itemCount - 1
                list.RemoveAt(e.OldStartingIndex)
            Next
        End Sub
    
        Private Sub ReplaceItems(ByVal list As IList, ByVal e As NotifyCollectionChangedEventArgs, ByVal converter As Converter(Of Object, Object))
            RemoveItems(list, e, converter)
            AddItems(list, e, converter)
        End Sub
    
        Private Sub SetListValuesFromSource(ByVal sourceList As IList, ByVal targetList As IList, ByVal converter As Converter(Of Object, Object))
            StopListeningForChangeEvents(targetList)
    
            targetList.Clear()
    
            For Each o As Object In sourceList
                targetList.Add(converter(o))
            Next
    
            ListenForChangeEvents(targetList)
        End Sub
    
        Private Function TargetAndMasterCollectionsAreEqual() As Boolean
            Return _masterList.Cast(Of Object)().SequenceEqual(_targetList.Cast(Of Object)().[Select](Function(item) ConvertFromTargetToMaster(item)))
        End Function
    
        ''' <summary>
        ''' Makes sure that all synchronized lists have the same values as the source list.
        ''' </summary>
        ''' <param name="sourceList">The source list.</param>
        Private Sub UpdateListsFromSource(ByVal sourceList As IList)
            If sourceList Is _masterList Then
                SetListValuesFromSource(_masterList, _targetList, AddressOf ConvertFromMasterToTarget)
            Else
                SetListValuesFromSource(_targetList, _masterList, AddressOf ConvertFromTargetToMaster)
            End If
        End Sub
    
    
    
    
        ''' <summary>
        ''' An implementation that does nothing in the conversions.
        ''' </summary>
        Friend Class DoNothingListItemConverter
            Implements IListItemConverter
    
            ''' <summary>
            ''' Converts the specified master list item.
            ''' </summary>
            ''' <param name="masterListItem">The master list item.</param>
            ''' <returns>The result of the conversion.</returns>
            Public Function Convert(ByVal masterListItem As Object) As Object Implements IListItemConverter.Convert
                Return masterListItem
            End Function
    
            ''' <summary>
            ''' Converts the specified target list item.
            ''' </summary>
            ''' <param name="targetListItem">The target list item.</param>
            ''' <returns>The result of the conversion.</returns>
            Public Function ConvertBack(ByVal targetListItem As Object) As Object Implements IListItemConverter.ConvertBack
                Return targetListItem
            End Function
        End Class
    
    End Class
