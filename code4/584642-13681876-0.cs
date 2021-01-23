     public class PerformanceTests
        {
            public StopWatch SW1 { get; set; }
    
            public StopWatch SW2 { get; set; }
    
            public string Results1 { get; set; }
    
            public string Results2 { get; set; }
    
            public PerformanceTests()
            {
                this.SW1 = new StopWatch();
                this.SW2 = new StopWatch();
            }
        }
