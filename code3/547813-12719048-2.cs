    try
    {
    
    }
    catch(Exception ex)
    {
        if(ex.GetType() == typeof(System.InvalidOperationException))
        {
              //Do something
        }
        else if(ex.GetType() == typeof(System.Web.Services.Protocols.SoapException))
        {
              //Do something
        }
        .
        .
    }
