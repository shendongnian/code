    public class UserAccess : JobProcessor
    {
        public void AddUser(User user)
        {
            QueueJob(() =>
                     {
                         using (var db = new CenterPlaceModelContainer())
                         {
                             db.Users.Add(user);
                         }
                     });
         [...]
    public abstract class JobProcessor<T>
    {
        // Subject<Action>
        private Subject<Action> JobSubject = new Subject<Action>();
        public JobProcessor()
        {
            JobSubject
            /* Insert Rx Operators Here */
            .Subscribe(OnJobNext, OnJobError, OnJobComplete);
        }
        private void OnJobNext(Action action)
        {
            // Log something saying "Yo, I'm executing an action" here?
            action();
        }
        private void OnJobError(Exception exception)
        {
            // Log something saying "Yo, something broke" here?
        }
        private void OnJobComplete()
        {
            // Log something saying "Yo, we shut down" here?
        }
        public void QueueJob(Action action)
        {
            JobSubject.OnNext(action);
        }
    }
