    public abstract class A
    {
        public EventHandler<EventArgs> OnThresholdViolated;
        public abstract void CheckThreshold();
    }
    public class B : A
    {
        public B(EventHandler<EventArgs> alertMe) {
            OnThresholdViolated += alertMe;
        }
        public override void CheckThreshold()
        {
            if (null != OnThresholdViolated)
            {
                OnThresholdViolated(this, EventArgs.Empty);
            }
        }
    }
