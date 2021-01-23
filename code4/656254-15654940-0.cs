    public class WPFUIDispatcherService : IDispatcherService
    {
        public void Invoke(Action action)
        {
            // check if the calling thread is the ui thread 
            if (Application.Current.Dispatcher.CheckAccess())
            {
                // current thread is ui thread -> directly fire the event
                action.DynamicInvoke();
            }
            else
            {
                // current thread is not ui thread so marshall the event to the ui thread
                Application.Current.Dispatcher.Invoke(action);
            }
        }
    }
