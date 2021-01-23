    Protected Sub GetAllCustomersData()
        ' List to Hold the results
        'Type of binding
        Dim myBinding As New BasicHttpBinding
        'Endpoint name defining
        Dim myEndPoint As New EndpointAddress(ConfigurationManager.AppSettings("CustomerServiceUrl").ToString())
        'Registering Service Reference
        Dim MychannelFactory As ChannelFactory(Of ICustomer) = New ChannelFactory(Of ICustomer)(myBinding, myEndPoint)
        'Creating a Channel to access Services
        Dim client As ICustomer = MychannelFactory.CreateChannel
        lst = client.GetCustomerData()
        grdCustomers.DataSource = lst
        grdCustomers.DataBind()
    End Sub
