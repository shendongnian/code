    try
    {
      DoSomethingThatThrowsACustomWidgetException() ;
    }
    catch ( Exception e )
    {
      CustomWidgetException cwe = e as CustomWidgetException ;
      if ( cwe == null ) throw ;
      int errorCode = cwe.ErrorCode ;
      ...
    }
