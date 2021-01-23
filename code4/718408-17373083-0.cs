    private DispatcherOperation pendingDefragOperation;
    protected void ScheduleDefrag()
    {
        if (pendingDefragOperation == null)
        {
            pendingDefragOperation = Dispatcher.BeginInvoke( 
                DispatcherPriority.Render, // You may want to play around with this
                new Action(Defrag));
        }
    }
