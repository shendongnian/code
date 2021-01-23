    public class DataContext : DbContext {
        public TimeSpan GetTimeSpan(Int64 ticks) {
            return TimeSpan.FromTicks(ticks);
        }
    
        // ... other code
    }
