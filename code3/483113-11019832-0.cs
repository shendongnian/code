    try { ... connect... }
    catch(SocketException ex) { 
      switch(ex.ErrorCode)
      {
        case 123: ....
        default: ....
      }
    }
    catch(WebException ex) { 
      if(ex.InnerException is SocketException)
      {
        switch(((SocketException)ex.InnerException).ErrorCode)
        {
          case 123: ....
          default: ....
        }
      }
      switch(ex.Status)
      {
        case 500: ....
        default: ....
      }
    }
    ....
    catch(Exception ex) { .... something unforeseen, send error report .... }
