    Imports System.Data.Common
    Imports System.Reflection
    Imports System.Runtime.CompilerServices
    
    ' Namespace Extensions
    
    ''' <summary>
    ''' Delegate event handler used with the <c>DbDataAdapter.RowUpdated</c> event.
    ''' </summary>
    ''' 
    Public Delegate Sub RowUpdatedEventHandler(sender As Object, e As RowUpdatedEventArgs)
    
    ''' <summary>
    ''' Delegate event handler used with the <c>DbDataAdapter.RowUpdating</c> event.
    ''' </summary>
    ''' 
    Public Delegate Sub RowUpdatingEventHandler(sender As Object, e As RowUpdatingEventArgs)
    
    Public Module DbDataAdapterExtension
    
        Sub New()
        End Sub
    
        Private Function GetEvent(eventName As String, type As Type) As EventInfo
            Return type.GetEvent(eventName, BindingFlags.[Public] Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)
        End Function
    
        ''' <summary>
        ''' Registers a <c>RowUpdatedEventHandler</c> with this instance's <c>RowUpdated</c> event.
        ''' </summary>
        ''' <param name="handler">The event handler to register for the event.</param>
        ''' <returns><c>true</c> if the event handler was successfully registered, otherwise <c>false</c>.</returns>
        ''' 
        <Extension> Public Function AddRowUpdatedHandler(adapter As DbDataAdapter, handler As RowUpdatedEventHandler) As Boolean
    
            Dim updEvent As EventInfo = GetEvent("RowUpdated", adapter.[GetType]())
    
            If updEvent IsNot Nothing Then
                Try
                    If handler.Method.IsStatic Then
                        updEvent.AddEventHandler(adapter, [Delegate].CreateDelegate(updEvent.EventHandlerType, handler.Method))
                    Else
                        updEvent.AddEventHandler(adapter, [Delegate].CreateDelegate(updEvent.EventHandlerType, handler.Target, handler.Method))
                    End If
    
                    Return True
                Catch
                End Try
            End If
    
            Return False
        End Function
    
        ''' <summary>
        ''' Registers a <c>RowUpdatingEventHandler</c> with this instance's <c>RowUpdating</c> event.
        ''' </summary>
        ''' <param name="handler">The event handler to register for the event.</param>
        ''' <returns><c>true</c> if the event handler was successfully registered, otherwise <c>false</c>.</returns>
        ''' 
        <Extension> Public Function AddRowUpdatingHandler(adapter As DbDataAdapter, handler As RowUpdatingEventHandler) As Boolean
    
            Dim updEvent As EventInfo = GetEvent("RowUpdating", adapter.[GetType]())
    
            If updEvent IsNot Nothing Then
                Try
                    If handler.Method.IsStatic Then
                        updEvent.AddEventHandler(adapter, [Delegate].CreateDelegate(updEvent.EventHandlerType, handler.Method))
                    Else
                        updEvent.AddEventHandler(adapter, [Delegate].CreateDelegate(updEvent.EventHandlerType, handler.Target, handler.Method))
                    End If
    
                    Return True
                Catch
                End Try
            End If
    
            Return False
        End Function
    End Module
    
    ' End Namespace
