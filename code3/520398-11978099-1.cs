    void Main()
    {
        string [] lines = {
    "[2012-07-05 00:01:07,008]  [INFO ] [MessageManager]  [3780] () [] [Starting     ProcessNewMessageEvent]",
    "[2012-07-05 00:01:07,008]  [INFO ] [MessageManager]  [3780] () [] [Method: RegValue]",
    "[2012-07-05 00:01:07,008]  [DEBUG] [MessageManager]  [3780] () [] [reg: InstallPath]",
    @"Exception: System.ServiceModel.EndpointNotFoundException
    Message: There was no endpoint listening at that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.
    Source: mscorlib",
    "[2012-07-04 23:55:59,598]  [INFO ] [MessageManager]  [6616] () [] [Method: RegValue]",
    "[2012-07-04 23:55:59,598]  [DEBUG] [MessageManager]  [6616] () [] [reg: InstallPath]"
        };
        
           var exceptions = lines.Where(l => l.Contains("Exception:"))
                              .Select(line => 
                              { 
                                 var items = line.Split(':');
                                 var result = new  
                                              {
                                                 OlogException = items.ElementAtOrDefault(1),
                                                 OlogMessage =   items.ElementAtOrDefault(2),
                                                 OlogSource = items.ElementAtOrDefault(3),
                                                 OlogServerStackTrace = items.ElementAtOrDefault(4)
                                              };
                                 return result;
                              });
    
        var groups = lines.Where(l => l.StartsWith("["))
                          .Select(line => 
                           { 
                              var items = line.Split('[', ']', '(', ')');
                              var result = new 
                                           {
                                              OlogDate = items.ElementAtOrDefault(1),
                                              OlogLevel = items.ElementAtOrDefault(3),
                                              OlogLogger = items.ElementAtOrDefault(5),
                                              OlogThread = items.ElementAtOrDefault(7),
                                              OlogProperty = items.ElementAtOrDefault(9),
                                              OlogMethod = items.ElementAtOrDefault(11),
                                              OlogException = items.ElementAtOrDefault(13)
                                            };
                              return result;
                           });
    
      exceptions.Dump();
      groups.Dump();
        
        
    }
