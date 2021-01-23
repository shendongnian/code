    Imports System.Reactive
    Imports System.Reactive.Linq
    Imports System.Reactive.Threading.Tasks
    Imports System.Threading
    Imports System.Net
    Imports System.Net.Sockets
    Public Module UDP
        ''' <summary>
        ''' Generates an IObservable as a UDP stream on the IP endpoint with an optional
        ''' timeout value between results.
        ''' </summary>
        ''' <param name="timeout"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function StreamObserver(
                    localPort As Integer, 
                    Optional timeout As Nullable(Of TimeSpan) = Nothing
                    ) As IObservable(Of UdpReceiveResult)
            Return Linq.Observable.Using(Of UdpReceiveResult, UdpClient)(
                Function() New UdpClient(localPort),
                Function(udpClient)
                    Dim o = Observable.Defer(Function() udpClient.
                                                                    ReceiveAsync().
                                                                    ToObservable())
                    If Not timeout Is Nothing Then
                        Return Observable.Timeout(o.Repeat(), timeout.Value)
                    Else
                        Return o.Repeat()
                    End If
                End Function
            )
        End Function
    End Module
