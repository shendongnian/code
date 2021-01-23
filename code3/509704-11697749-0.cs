    private void DetermineIfActionChanged(IAction lastAction)
    {
       IAction nextAction = GetNextAction();
       if (nextAction.GetType() != lastAction.GetType())
       {
           DoSomethingAwesome();
       }
    }
