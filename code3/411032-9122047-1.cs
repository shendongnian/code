    using ExWs = Microsoft.Exchange.WebServices.Data; 
     ExWs.ExchangeService service = new 
                       ExWs.ExchangeService(ExWs.ExchangeVersion.Exchange2007_SP1);
                        service.Credentials = new   
                       ExWs.WebCredentials("username", "password", "domain");
                        service.AutodiscoverUrl("name@company.com");
