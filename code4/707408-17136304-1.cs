    [Target("CustomTraceListener")]
    public sealed class MyFirstTarget : TargetWithLayout
    {
        
        public Layout ApplicationUser { get; set; }
        protected override void Write(LogEventInfo logEvent)
        {
            string logMessage = this.Layout.Render(logEvent);
            string applicationUser = ApplicationUser.Render(logEvent);
            // ... Write where you want
        }
    } 
