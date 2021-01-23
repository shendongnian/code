    Imports System.Threading
    Imports System.Runtime.InteropServices
    Imports Microsoft.Practices.Composite.Events
    Public Class EventAggregatorSingleton
    Private Shared _currentEventAggregator As EventAggregator
    Private Shared _syncLock As Object = New Object()
    Public Shared ReadOnly Property CurrentEventAggregator As EventAggregator
        Get
            If _currentEventAggregator Is Nothing Then
                SyncLock _syncLock
                    If _currentEventAggregator Is Nothing Then
                        Dim currEventAggregator As New EventAggregator
                        _currentEventAggregator = currEventAggregator
                    End If
                End SyncLock
            End If
            Return _currentEventAggregator
        End Get
    End Property
    End Class
