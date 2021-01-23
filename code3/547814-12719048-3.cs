    try
    {
    
    }
    catch(Exception ex)
    {
        if(ex.GetType() == typeof(System.InvalidOperationException))
        {
              //cast ex to InvalidOperationException
              ((InvalidOperationException)ex).SomeMethod();
        }
        else if(ex.GetType() == typeof(System.Web.Services.Protocols.SoapException))
        {
              //cast ex to System.Web.Services.Protocols.SoapException
              ((System.Web.Services.Protocols.SoapException)ex).SomeMethod();
        }
        .
        .
    }
