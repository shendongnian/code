    DateTime dte1 = (DateTime)entity.secondDate;
    DateTime dte2 = (DateTime)entity.firstDate;
    
    if (DateTime.Compare(DateTime.ParseExact(dte1.ToString("yyyy-MM-dd hh:mm:ss"), 
                                                           "yyyy-MM-dd hh:mm:ss", 
                                                            null), 
                         DateTime.ParseExact(dte2.ToString("yyyy-MM-dd hh:mm:ss"), 
                                                           "yyyy-MM-dd hh:mm:ss", 
                                                            null)) != 0)
    {
        throw new HttpRequestException(ExceptionMessages.CONCURRENCY_UPDATE);
    }
