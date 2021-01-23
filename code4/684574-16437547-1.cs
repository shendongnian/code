    // This is the class handling the timer ticks
    public class ActionExecutor
    {
        private Timer timer;
        private IList<Action> actionsList = new List<Action>();
        public ActionExecutor()
        {
            //choose the interval as suits you best, or use constructor
            timer = new Timer(1000);
            timer.Elapsed += OnTimerTick;
            timer.AutoReset = true;
            timer.Start();
        }
    
        void OnTimerTick(object sender, ElapsedEventArgs)
        {
            lock(actionsList)
            {
                foreach(Action a in actionsList) 
                {
                    a();
                }
                actionsList.Clear();
            }
        }
        public void AddAction(Action a)
        {
            lock(actionList)
            {
                actionList.Add(a);
            }
        }
    }
_______
    
    //handling user click in your application
    
    void OnUserClick() 
    {
        // built the specific notification request
        NotificationMessageRequest request = ...
    
        actionExecutor.AddAction(() => SendNotificationMessage(request));
    }
