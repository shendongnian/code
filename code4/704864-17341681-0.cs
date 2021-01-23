    if(string.IsNullOrEmpty(cityVal ))
    {
    var obj=  new
                    {
                        Country= countryVal,
                        Keyword = key,
                        Page = page
                    };
    
    // do something
    return obj;
    }
    else
    {
    var obj=  new
                    {
                        Country= countryVal,
                        City = cityVal,
                        Keyword = key,
                        Page = page
                    };
    
    //do something 
    return obj;
    }
     
