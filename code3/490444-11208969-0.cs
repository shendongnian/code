    you can use this code :
        
        var Hours = Math.floor(Yourvariable/60);
        var Minutes = Yourvariable%60;
    
    Or you can use this
    
    var span = System.TimeSpan.FromMinutes(Yourvariable);
    var hours = ((int)span.TotalHours).ToString();     
    var minutes = span.Minutes.ToString();
