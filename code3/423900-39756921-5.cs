            [HttpGet]
            [PreventDirectAccess]//It is my custom filters
            // ---> /Index/SearchCustomer?input={input}/
            public string SearchCustomer(string input)
            {
                try
                {
                    var isJsonRequestOnMVC = Request.Headers["Accept"];//TODO: This will check if the request comes from MVC else comes from Browser
                    if (!isJsonRequestOnMVC.Contains("application/json")) return "Error Request on server!";
    
                    var serialize = new JavaScriptSerializer();
                    ISearch customer = new SearchCustomer();
                    IEnumerable<ContactInfoResult> returnSearch = customer.GetCustomerDynamic(input);
    
                    return serialize.Serialize(returnSearch);
                }
                catch (Exception err)
                {
                    throw;
                }
            }
