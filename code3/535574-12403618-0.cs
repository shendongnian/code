    Imports System
    Imports System.Text
    Imports System.IO
    Imports System.Diagnostics
    Imports System.Threading
    Imports System.ComponentModel
    Imports Microsoft.VisualBasic
    
    Imports System.Collections.Generic
    Imports System.Linq
    
    
    Imports System.Collections
    
    
    
    Module Module2
    
    
        Friend Delegate Sub UserCallBack(ByVal data As String)
        Public Delegate Sub DataReceivedEventHandler(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
    
    
    
    
        Public Class FixedProcess
            Inherits Process
            Friend output As AsyncStreamReader
            Friend [error] As AsyncStreamReader
            Public Shadows Event OutputDataReceived As DataReceivedEventHandler
            Public Shadows Event ErrorDataReceived As DataReceivedEventHandler
    
            Public CancelAll As Boolean = False
    
            Public Overloads Sub BeginOutputReadLine()
                Dim baseStream As Stream = StandardOutput.BaseStream
                Me.output = New AsyncStreamReader(Me, baseStream, New UserCallBack(AddressOf Me.FixedOutputReadNotifyUser), StandardOutput.CurrentEncoding)
                Me.output.BeginReadLine()
            End Sub
    
            Public Overloads Sub BeginErrorReadLine()
                Dim baseStream As Stream = StandardError.BaseStream
                Me.[error] = New AsyncStreamReader(Me, baseStream, New UserCallBack(AddressOf Me.FixedErrorReadNotifyUser), StandardError.CurrentEncoding)
                Me.[error].BeginReadLine()
            End Sub
    
            Friend Sub FixedOutputReadNotifyUser(ByVal data As String)
                Dim dataReceivedEventArgs As New DataReceivedEventArgs(data)
                RaiseEvent OutputDataReceived(Me, dataReceivedEventArgs)
    
            End Sub
    
    
    
    
    
            Friend Sub FixedErrorReadNotifyUser(ByVal data As String)
                Dim errorDataReceivedEventArgs As New DataReceivedEventArgs(data)
                RaiseEvent ErrorDataReceived(Me, errorDataReceivedEventArgs)
    
            End Sub
    
    
    
    
        End Class
    
        Friend Class AsyncStreamReader
            Implements IDisposable
            Friend Const DefaultBufferSize As Integer = 1024
            Private Const MinBufferSize As Integer = 128
            Private stream As Stream
            Private encoding As Encoding
            Private decoder As Decoder
            Private byteBuffer As Byte()
            Private charBuffer As Char()
            Private _maxCharsPerBuffer As Integer
            Private process As Process
            Private userCallBack As UserCallBack
            Public cancelOperation As Boolean
            Private eofEvent As ManualResetEvent
            Private messageQueue As Queue
            Private sb As StringBuilder
            Private bLastCarriageReturn As Boolean
            Public Overridable ReadOnly Property CurrentEncoding() As Encoding
                Get
                    Return Me.encoding
                End Get
            End Property
            Public Overridable ReadOnly Property BaseStream() As Stream
                Get
                    Return Me.stream
                End Get
            End Property
            Friend Sub New(ByVal process As Process, ByVal stream As Stream, ByVal callback As UserCallBack, ByVal encoding As Encoding)
                Me.New(process, stream, callback, encoding, 1024)
            End Sub
            Friend Sub New(ByVal process As Process, ByVal stream As Stream, ByVal callback As UserCallBack, ByVal encoding As Encoding, ByVal bufferSize As Integer)
                Me.Init(process, stream, callback, encoding, bufferSize)
                Me.messageQueue = New Queue()
            End Sub
            Private Sub Init(ByVal process As Process, ByVal stream As Stream, ByVal callback As UserCallBack, ByVal encoding As Encoding, ByVal bufferSize As Integer)
                Me.process = process
                Me.stream = stream
                Me.encoding = encoding
                Me.userCallBack = callback
                Me.decoder = encoding.GetDecoder()
                If bufferSize < 128 Then
                    bufferSize = 128
                End If
                Me.byteBuffer = New Byte(bufferSize - 1) {}
                Me._maxCharsPerBuffer = encoding.GetMaxCharCount(bufferSize)
                Me.charBuffer = New Char(Me._maxCharsPerBuffer - 1) {}
                Me.cancelOperation = False
                Me.eofEvent = New ManualResetEvent(False)
                Me.sb = Nothing
                Me.bLastCarriageReturn = False
            End Sub
            Public Overridable Sub Close()
                Me.Dispose(True)
            End Sub
            Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
                Me.Dispose(True)
                GC.SuppressFinalize(Me)
            End Sub
            Protected Overridable Sub Dispose(ByVal disposing As Boolean)
                If disposing AndAlso Me.stream IsNot Nothing Then
                    Me.stream.Close()
                End If
                If Me.stream IsNot Nothing Then
                    Me.stream = Nothing
                    Me.encoding = Nothing
                    Me.decoder = Nothing
                    Me.byteBuffer = Nothing
                    Me.charBuffer = Nothing
                End If
                If Me.eofEvent IsNot Nothing Then
                    Me.eofEvent.Close()
                    Me.eofEvent = Nothing
                End If
            End Sub
            Friend Sub BeginReadLine()
                If Me.cancelOperation Then
                    Me.cancelOperation = False
                End If
                If Me.sb Is Nothing Then
                    Me.sb = New StringBuilder(1024)
                    Me.stream.BeginRead(Me.byteBuffer, 0, Me.byteBuffer.Length, New AsyncCallback(AddressOf Me.ReadBuffer), Nothing)
                    Return
                End If
                Me.FlushMessageQueue()
            End Sub
            Friend Sub _CancelOperation()
                Me.cancelOperation = True
            End Sub
            Private Sub ReadBuffer(ByVal ar As IAsyncResult)
    
                Dim num As Integer
    
                Try
                    num = Me.stream.EndRead(ar)
                Catch generatedExceptionName As IOException
                    num = 0
                Catch generatedExceptionName As OperationCanceledException
                    num = 0
                End Try
                If num = 0 Then
                    SyncLock Me.messageQueue
                        If Me.sb.Length <> 0 Then
                            Me.messageQueue.Enqueue(Me.sb.ToString())
                            Me.sb.Length = 0
                        End If
                        Me.messageQueue.Enqueue(Nothing)
                    End SyncLock
                    Try
                        Me.FlushMessageQueue()
                        Return
                    Finally
                        Me.eofEvent.[Set]()
                    End Try
                End If
                Dim chars As Integer = Me.decoder.GetChars(Me.byteBuffer, 0, num, Me.charBuffer, 0)
                Me.sb.Append(Me.charBuffer, 0, chars)
                Me.GetLinesFromStringBuilder()
                Me.stream.BeginRead(Me.byteBuffer, 0, Me.byteBuffer.Length, New AsyncCallback(AddressOf Me.ReadBuffer), Nothing)
    
    
            End Sub
            Private Sub GetLinesFromStringBuilder()
                Dim i As Integer = 0
                Dim num As Integer = 0
                Dim length As Integer = Me.sb.Length
                If Me.bLastCarriageReturn AndAlso length > 0 AndAlso Me.sb(0) = ControlChars.Lf Then
                    i = 1
                    num = 1
                    Me.bLastCarriageReturn = False
                End If
                While i < length
                    Dim c As Char = Me.sb(i)
                    If c = ControlChars.Cr OrElse c = ControlChars.Lf Then
                        If c = ControlChars.Cr AndAlso i + 1 < length AndAlso Me.sb(i + 1) = ControlChars.Lf Then
                            i += 1
                        End If
    
                        Dim obj As String = Me.sb.ToString(num, i + 1 - num)
    
                        num = i + 1
    
                        SyncLock Me.messageQueue
                            Me.messageQueue.Enqueue(obj)
                        End SyncLock
                    End If
                    i += 1
                End While
    
                ' Flush Fix: Send Whatever is left in the buffer
                Dim endOfBuffer As String = Me.sb.ToString(num, length - num)
                SyncLock Me.messageQueue
                    Me.messageQueue.Enqueue(endOfBuffer)
                    num = length
                End SyncLock
                ' End Flush Fix
    
                If Me.sb(length - 1) = ControlChars.Cr Then
                    Me.bLastCarriageReturn = True
                End If
                If num < length Then
                    Me.sb.Remove(0, num)
                Else
                    Me.sb.Length = 0
                End If
                Me.FlushMessageQueue()
            End Sub
            Private Sub FlushMessageQueue()
                While Me.messageQueue.Count > 0
                    SyncLock Me.messageQueue
                        If Me.messageQueue.Count > 0 Then
                            Dim data As String = DirectCast(Me.messageQueue.Dequeue(), String)
                            If Not Me.cancelOperation Then
                                Me.userCallBack(data)
                            End If
                        End If
                        Continue While
                    End SyncLock
                    Exit While
                End While
            End Sub
            Friend Sub WaitUtilEOF()
                If Me.eofEvent IsNot Nothing Then
                    Me.eofEvent.WaitOne()
                    Me.eofEvent.Close()
                    Me.eofEvent = Nothing
                End If
            End Sub
        End Class
    
        Public Class DataReceivedEventArgs
            Inherits EventArgs
            Friend _data As String
            ''' <summary>Gets the line of characters that was written to a redirected <see cref="T:System.Diagnostics.Process" /> output stream.</summary>
            ''' <returns>The line that was written by an associated <see cref="T:System.Diagnostics.Process" /> to its redirected <see cref="P:System.Diagnostics.Process.StandardOutput" /> or <see cref="P:System.Diagnostics.Process.StandardError" /> stream.</returns>
            ''' <filterpriority>2</filterpriority>
            Public ReadOnly Property Data() As String
                Get
                    Return Me._data
                End Get
            End Property
            Friend Sub New(ByVal data As String)
                Me._data = data
            End Sub
        End Class
    
    
    
    
    
    
    End Module
