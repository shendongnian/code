    Private customers As List(Of CService.Customer)
    Private Sub GetCustomers()
     Dim cs As New CService.CustomerClient
     Addhandler cs.GetCustomersCompleted, AddressOf CustomersCompleted
     cs.GetCustomersAsync()
    End Sub
    Private Sub CustomersCompleted(sender As Object, e As GetCustomersEventArgs)
      customers = e.Result
    End If
