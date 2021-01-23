    Imports System.Net.NetworkInformation
    Imports System.Threading
    
    Module Module1
    
        Private pingers As New List(Of Ping)
    
        Private instances As Integer = 0
        Private result As Integer = 0
    
        Private timeOut As Integer = 250
        Private ttl As Integer = 5
    
        Sub Main()
    
            Dim baseIP As String = "192.168.1."
            Dim classD As Integer = 1
    
            Console.WriteLine("Pinging 255 destinations of D-class in {0}*", baseIP)
    
            CreatePingers(255)
    
            Dim po As New PingOptions(ttl, True)
            Dim enc As New System.Text.ASCIIEncoding
            Dim data As Byte() = enc.GetBytes("abababababababababababababababab")
    
            Dim wait As New SpinWait
            Dim cnt As Integer = 1
    
            Dim watch As Stopwatch = Stopwatch.StartNew
    
            For Each p As Ping In pingers
                instances += 1
                p.SendAsync(String.Concat(baseIP, cnt.ToString), timeOut, data, po)
                cnt += 1
            Next
    
            Do While instances > 0
                wait.SpinOnce()
            Loop
    
            watch.Stop()
    
            DestroyPingers()
    
            Console.WriteLine("Finished in {0}. Found {1} active IP-addresses.", watch.Elapsed.ToString, result)
            Console.ReadKey()
    
        End Sub
    
        Sub Ping_completed(s As Object, e As PingCompletedEventArgs)
    
            instances -= 1
    
            If e.Reply.Status = IPStatus.Success Then
                Console.WriteLine(String.Concat("Active IP: ", e.Reply.Address.ToString))
                result += 1
            Else
                'Console.WriteLine(String.Concat("Non-active IP: ", e.Reply.Address.ToString))
            End If
    
        End Sub
    
        Private Sub CreatePingers(cnt As Integer)
    
            For i As Integer = 1 To cnt
                Dim p As New Ping
                AddHandler p.PingCompleted, AddressOf Ping_completed
                pingers.Add(p)
            Next
        End Sub
        Private Sub DestroyPingers()
    
            For Each p As Ping In pingers
                RemoveHandler p.PingCompleted, AddressOf Ping_completed
                p.Dispose()
            Next
    
            pingers.Clear()
    
        End Sub
    
    End Module
