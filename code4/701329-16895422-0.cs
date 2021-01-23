    // add these fields
    
    private TimeSpan[] _interval;
    private DateTime[] _startTime;
    
    // when you create timer1 array, need to initialize the above arrays
    
    int len = timer1.Length;
    _interval = new TimeSpan[len];
    _startTime = new DateTime[len];
    
    // change SetTimers method as follows;
    
    public void SetTimers(int timer, DataRow row)
    {
       TimeSpan dueTime;
       TimeSpan interval;
       SetTimeIntervals(row, out dueTime, out interval); 
       
       _interval[timer] = interval;
       _startTime[timer] = DateTime.Now + dueTime;
       object[] obj = new object[2]{row, timer};              
       timer1[timer] = new System.Threading.Timer(databaseTrensfer, obj, dueTime, interval);  
    }
    
    // change databaseTrensfer method as follows
    
    public void databaseTrensfer(object state)
    {
       object[] obj = (object[])state;
       DataRow row = (DataRow)obj[0];
       string alarmType = Convert.ToString(row["EBase"]);
       if (alarmType != "Milisecond" && alarmType != "Once")
       {
          int timer = (int)obj[1];
          DateTime dt = DateTime.Now;
          long elapsedMs = Convert.ToInt64((dt - _startTime[timer]).TotalMilliseconds);
          long intervalMs = Convert.ToInt64(_interval[timer].TotalMilliseconds);
          long remainder = elapsedMs % intervalMs;
          if (remainder != 0L)
          {
             timer1[timer].Change(_interval[timer] - TimeSpan.FromMilliseconds(remainder), _interval[timer]);
          }
       }  
       //code      
    }
