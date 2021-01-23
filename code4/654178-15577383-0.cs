    //Using these, as defined in the question
    double M;
    int N;
    DateTime start; //Taken from W
    DateTime end; //Taken from W
    
    //Set these up.
    Random rand = new Random();
    List<DateTime> times;
    //This assumes that M is 
    TimeSpan waitTime = new TimeSpan.FromHours(M);
    int totalSeconds = ((TimeSpan)end-start).TotalSeconds;
    
    while( times.Count < N )
    {
        int seconds = rand.Next(totalSeconds);
        DateTime next = start.AddSeconds(seconds);
        bool valid = true;
        if( times.Count > 0 )
        {
            foreach( DateTime dt in times )
            {
                valid = (dt > next && ((TimeSpan)dt - next) > waitTime) ? true : false;
                if( !valid )
                {
                    break;
                }
            }
        }
        if( valid )
        {
            times.Add(next);
        }
    }
