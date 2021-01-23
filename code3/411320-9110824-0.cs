    public decimal Duration {get;set;}
    public void SetDuration(object duration)
    {
       if(duration is decimal)
          Duration = (decimal)duration;
       else if(duration is string)
       { 
          Duration = decimal.Parse((string)duration);
       }
    }
