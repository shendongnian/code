    public class BaseEvent
    {
        public DateTime TimeStamp;
        public virtual void Render() { }
    }
    public class Swimming : BaseEvent
    {
        public override void Render()
        {
            // Code to render a Swimming instance
        }
    }
    public class Cycling: BaseEvent
    {
        public override void Render()
        {
            // Code to render a Cycling instance
        }
    }
