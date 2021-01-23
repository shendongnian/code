    Public Shared ReadOnly Property IpAddress() As String
            Get
                If String.IsNullOrWhiteSpace(_ipAddress) Then
                    Try
                        Dim webClient As New WebClient
                        Dim result As String = webClient.DownloadString("http://checkip.dyndns.org")
    
                        Dim fields = result.Split(" ")
                        _ipAddress = fields.Last
                        _ipAddress = _ipAddress.Replace("</body></html>", "")
                    Catch ex As Exception
                        _ipAddress = "errorFindingIp"
                    End Try
                End If
                Return _ipAddress
            End Get
        End Property
