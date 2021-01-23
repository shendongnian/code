    try
    {
    }
    catch (Exception ex)
    {
                EventAggregator.GetEvent<RaisedExceptionEvent>().Publish(new ExceptionManager(ex,
                                                                                              ExceptionMessageType.
                                                                                                  Default, true));
    }
