    Action backgroundAction = new Action(DoAction);
    backgroundAction.BeginInvoke(ActionCallback, null);
    
    private void DoAction()
    {
        //some background task
    }
    
    private void ActionCallback(IAsyncResult result)
    {
       //will be executed after
    }
