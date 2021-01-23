    var errorLines = File.Where(e => e.Level == "ERR" 
                                  || e.Level == "WARN");                   
    if (!string.IsNullOrEmpty(errorStartTime))
    {
         var sTime = DateTime.Parse(errorStartTime);
         errorLines = errorLines.Where(e => e.DateTime >= sTime);
    }
    if (!string.IsNullOrEmpty(errorTime))
    {
        var eTime = DateTime.Parse(errorTime);
        errorLines = errorLines.Where(e => e.DateTime <= eTime);
    }
