    try
    {
    
    }
    catch(Exception ex)
    {
         switch (ex.GetType().ToString())
         {
             case "System.InvalidOperationException":
                  //cast ex to specific type of exception to use it's properties
                  ((InvalidOperationException)ex).SomeMethod();
             break;
             case "System.NotSupportedException":
                 ((System.NotSupportedException)ex).AnotherMethod();
             break;
             case "System.Web.Services.Protocols.SoapException":
                 ((System.Web.Services.Protocols.SoapException)ex).OtherMethod();
             break;
         }
    }
