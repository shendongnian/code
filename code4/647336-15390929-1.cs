    using(ServiceSecurityContext.Current.WindowsIdentity.Impersonate())
    {
        ExchangeService service = new ExchangeService(...)
        service.UseDefaultCredentials = true; 
     
    }
