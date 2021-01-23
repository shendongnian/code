    Protected Sub grdCustomers_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
    Dim result As Boolean
    Dim CustObj As New Services.Entities.Customers.Customer
    CustObj.CustomerID = DirectCast(grdCustomers.Rows(e.RowIndex).FindControl("lblCustomerId"), Label).Text
    CustObj.ContactName = DirectCast(grdCustomers.Rows(e.RowIndex).FindControl("txtContactName"), TextBox).Text
    CustObj.City = DirectCast(grdCustomers.Rows(e.RowIndex).FindControl("ddlCity1"), DropDownList).SelectedValue.ToString
    'Type of binding
    Dim myBinding As New BasicHttpBinding
    'Endpoint name defining
    Dim myEndPoint As New   EndpointAddress(ConfigurationManager.AppSettings("CustomerServiceUrl").ToString())
    Dim myChannelFactory As ChannelFactory(Of ICustomer) = New ChannelFactory(Of ICustomer)(myBinding, myEndPoint)
    'Creating a Channel to access Services
    Dim client As ICustomer = myChannelFactory.CreateChannel
    result = client.UpdateCustomerDetails(CustObj)
    grdCustomers.EditIndex = -1
    GetAllCustomersData()
    Sub End 
