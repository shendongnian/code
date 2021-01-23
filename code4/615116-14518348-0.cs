    public abstract class SubscriptionBase
    {
        public abstract void ExecuteAction(params object[] parameters);
    }
    public class Subscription<T> : SubscriptionBase
    {
        private T _action;
        public Subscription(T a)
        {
            _action = a;
        }
        public override void ExecuteAction(params object[] parameters)
        {
            (_action as Delegate).DynamicInvoke(parameters);
        }
    }
