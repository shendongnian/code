    //goes through each of the files in each folder and 
    foreach (string s in filePaths)
    {
        //goes through each line in each file
        string[] lines = System.IO.File.ReadAllLines(s);
    
        var exceptions = lines.Contains("Exception:")
                              .Select(line => 
                              { 
                                 var items = line.Split(':');
                                 var result = new ExTable() 
                                              {
                                                 OlogException = items [2],
                                                 OlogMessage = items [4],
                                                 OlogSource = items [6],
                                                 OlogServerStackTrace = items [8]
                                              };
                                 return result;
                              });
    
        var groups = lines.Filter(line => !line.Contains("Exception:"))
                          .Contains("[")   
                          .Select(line => 
                           { 
                              var items = line.Split('[', ']', '(', ')');
                              var result = new OLog() 
                                           {
                                              OlogDate = items [1],
                                              OlogLevel = items [3],
                                              OlogLogger = items [5],
                                              OlogThread = items [7],
                                              OlogProperty = items [9],
                                              OlogMethod = items [11],
                                              OlogException = items [12],
                                            };
                              return result;
                           });
    
           /// work with exceptions and groups list:
    
    }
