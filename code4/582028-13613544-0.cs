    public abstract class WidgetExample : IReady
    {
        public int WidgetCount { get; set; }
        public int WidgetTarget { get; set; }
        public bool WidgetsReady { get; set; }
        public WidgetExample()
        {
            WidgetCount = 3;
            WidgetTarget = 45;
        }
        public bool ComputeReadiness()
        {
            if (WidgetCount < WidgetTarget)
            {
                WidgetsReady = false;
            }
            return WidgetsReady;
        }
    }
    public class Foo : WidgetExample
    {
        public Foo()
        {
            this.WidgetTarget = 2;
        }
    }
    public class Bar : IReady
    {
        public bool ComputeReadiness()
        {
            return true;
        }
    }
