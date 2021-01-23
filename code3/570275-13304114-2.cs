    Public Sub CarService(ByVal car As ICar)
        If car Is Nothing Then
            Throw New ArgumentNullException("car")
        End If
        ' do logic here
    End Sub
