    Imports System.Collections
    Imports System.Windows
    Imports System.Windows.Controls.Primitives
    Imports System.Windows.Controls
    Imports System
    
    Public NotInheritable Class MultiSelectorBehaviours
        Private Sub New()
        End Sub
    
        Public Shared ReadOnly SynchronizedSelectedItems As DependencyProperty = _
            DependencyProperty.RegisterAttached("SynchronizedSelectedItems", GetType(IList), GetType(MultiSelectorBehaviours), New PropertyMetadata(Nothing, New PropertyChangedCallback(AddressOf OnSynchronizedSelectedItemsChanged)))
    
        Private Shared ReadOnly SynchronizationManagerProperty As DependencyProperty = DependencyProperty.RegisterAttached("SynchronizationManager", GetType(SynchronizationManager), GetType(MultiSelectorBehaviours), New PropertyMetadata(Nothing))
    
        ''' <summary>
        ''' Gets the synchronized selected items.
        ''' </summary>
        ''' <param name="dependencyObject">The dependency object.</param>
        ''' <returns>The list that is acting as the sync list.</returns>
        Public Shared Function GetSynchronizedSelectedItems(ByVal dependencyObject As DependencyObject) As IList
            Return DirectCast(dependencyObject.GetValue(SynchronizedSelectedItems), IList)
        End Function
    
        ''' <summary>
        ''' Sets the synchronized selected items.
        ''' </summary>
        ''' <param name="dependencyObject">The dependency object.</param>
        ''' <param name="value">The value to be set as synchronized items.</param>
        Public Shared Sub SetSynchronizedSelectedItems(ByVal dependencyObject As DependencyObject, ByVal value As IList)
            dependencyObject.SetValue(SynchronizedSelectedItems, value)
        End Sub
    
        Private Shared Function GetSynchronizationManager(ByVal dependencyObject As DependencyObject) As SynchronizationManager
            Return DirectCast(dependencyObject.GetValue(SynchronizationManagerProperty), SynchronizationManager)
        End Function
    
        Private Shared Sub SetSynchronizationManager(ByVal dependencyObject As DependencyObject, ByVal value As SynchronizationManager)
            dependencyObject.SetValue(SynchronizationManagerProperty, value)
        End Sub
    
        Private Shared Sub OnSynchronizedSelectedItemsChanged(ByVal dependencyObject As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            If e.OldValue IsNot Nothing Then
                Dim synchronizer As SynchronizationManager = GetSynchronizationManager(dependencyObject)
                synchronizer.StopSynchronizing()
    
                SetSynchronizationManager(dependencyObject, Nothing)
            End If
    
            Dim list As IList = TryCast(e.NewValue, IList)
            Dim selector As Selector = TryCast(dependencyObject, Selector)
    
            ' check that this property is an IList, and that it is being set on a ListBox
            If list IsNot Nothing AndAlso selector IsNot Nothing Then
                Dim synchronizer As SynchronizationManager = GetSynchronizationManager(dependencyObject)
                If synchronizer Is Nothing Then
                    synchronizer = New SynchronizationManager(selector)
                    SetSynchronizationManager(dependencyObject, synchronizer)
                End If
    
                synchronizer.StartSynchronizingList()
            End If
        End Sub
    
        ''' <summary>
        ''' A synchronization manager.
        ''' </summary>
        Private Class SynchronizationManager
            Private ReadOnly _multiSelector As Selector
            Private _synchronizer As TwoListSynchronizer
    
            ''' <summary>
            ''' Initializes a new instance of the <see cref="SynchronizationManager"/> class.
            ''' </summary>
            ''' <param name="selector">The selector.</param>
            Friend Sub New(ByVal selector As Selector)
                _multiSelector = selector
            End Sub
    
            ''' <summary>
            ''' Starts synchronizing the list.
            ''' </summary>
            Public Sub StartSynchronizingList()
                Dim list As IList = GetSynchronizedSelectedItems(_multiSelector)
    
                If list IsNot Nothing Then
                    _synchronizer = New TwoListSynchronizer(GetSelectedItemsCollection(_multiSelector), list)
                    _synchronizer.StartSynchronizing()
                End If
            End Sub
    
            ''' <summary>
            ''' Stops synchronizing the list.
            ''' </summary>
            Public Sub StopSynchronizing()
                _synchronizer.StopSynchronizing()
            End Sub
    
            Public Shared Function GetSelectedItemsCollection(ByVal selector As Selector) As IList
                If TypeOf selector Is MultiSelector Then
                    Return TryCast(selector, MultiSelector).SelectedItems
                ElseIf TypeOf selector Is ListBox Then
                    Return TryCast(selector, ListBox).SelectedItems
                Else
                    Throw New InvalidOperationException("Target object has no SelectedItems property to bind.")
                End If
            End Function
    
        End Class
    End Class
