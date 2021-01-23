    string params = string.Join(Environment.NewLine,
                                insert.Parameters
                                      .Select(p => string.Format("{0} : {1}",
                                                                 p.Name, 
                                                                 p.Value))
                                      .ToArray()
                                );
    
    string message = string.Format("{0}: {1}{2}\n{3}\n{4}",
                                   "OleDbException: " ,
                                   Globals.ERROR_INSERT_CLICK,
                                   oldbex.Message,
                                   insert.CommandText,
                                   params);
    logger.WriteToLog("GETCLICKS", message );
