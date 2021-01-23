    ServiceReference1.WebServiceSoapClient test = new ServiceReference1.WebServiceSoapClient();
    test.ReadTotalOutstandingInvoiceCompleted += (s,e) =>
    {
       // Do some things here
       NotifyComplete();
    };
    
    test.ReadTotalOutstandingInvoiceAsync();
