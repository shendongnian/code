    // This is the class handling the timer ticks
    public class ActionExecutor
    {
        IList<Action> actionsList = new List<Action>();
    
        void OnTimerTick(...) 
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
