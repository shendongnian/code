    using(var tm = new TimeMeasurementThreshold(TimeSpan.FromSeconds(1),"Sending mail block",logger)){
     // measured code here 
    }
    public class TimeMeasurementThreshold : IDisposable
        {
            private readonly Logger logger;
    
            private readonly TimeSpan thresholdTime;
    
            private readonly string codeBlockName;
    
            private readonly TimeMeasurement timeMeasurement;
    
            public TimeMeasurementThreshold(TimeSpan thresholdTime, string codeBlockName, Logger logger)
            {
                this.logger = logger;
                this.thresholdTime = thresholdTime;
                this.codeBlockName = codeBlockName;
    
                timeMeasurement = new TimeMeasurement();
            }
    
            public void Dispose()
            {
                TimeSpan elapsed = timeMeasurement.Elapsed;
    
                if (elapsed >= thresholdTime)
                {
                    logger.Debug("{0} execution time is {1:N0}ms", codeBlockName, elapsed.TotalMilliseconds);
                }
            }
        }
