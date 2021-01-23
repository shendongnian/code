    Imports System
    Imports System.Net
    Imports System.Net.NetworkInformation
    
    
    Public Class Pinger
    
        <System.Diagnostics.DebuggerNonUserCode()> _
            Public Sub New()
            MyBase.New()
    
            'This call is required by the Component Designer.
            InitializeComponent()
    
        End Sub
    
    
        Public Shared Function CanHostBePinged(ByVal IPAddr_DNS_OR_Host_Name As String) As Boolean
            Dim p As New Ping
            Dim po As New PingOptions
    
            po.Ttl = 256
            po.DontFragment = False
    
            Dim stringOut As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDE"
            Dim streamOut As Byte() = System.Text.Encoding.ASCII.GetBytes(stringOut)
    
            Try
                Dim reply As PingReply = p.Send(IPAddr_DNS_OR_Host_Name, 30, streamOut)
                If reply.Status = IPStatus.Success Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
    
        End Function
    
    
    End Class
