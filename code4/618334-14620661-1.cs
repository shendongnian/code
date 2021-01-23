     public class FilterExceptions : TraceFilter
        {
            public override bool ShouldTrace(TraceEventCache cache, string source, TraceEventType eventType, int id, string formatOrMessage, object[] args, object data1, object[] data)
            {
                // Add exception filter in below if when event type is error
                if (eventType == TraceEventType.Error)
                {
                    return false;
                }
    
                return true;
            }
        }
