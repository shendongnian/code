    try
    {
      serviceProxyGlobal.Method()
    }
    catch(WhateverServerTimeoutException ex)
    {
      serviceProxyGlobal = new ServiceProxy();
      //retry maybe?
    }
    catch(Exception ex)
    {
      logException(ex);
    }
