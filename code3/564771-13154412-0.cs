    [Target("Foo")]
    public class FooTarget : TargetWithLayout
    {
        protected override void Write(LogEventInfo logEvent)
        {            
            Console.WriteLine(logEvent.Message);
        }
    }
