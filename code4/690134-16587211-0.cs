    public bool PerformAction(ActionToPerform actionToPerform)
    {
        bool isPerformed = false;
        var foundAction = Actions.SingleOrDefault(a => a.Code == actionToPerform.Action.Code);
        if (foundAction != null)
        {
            isPerformed = foundAction.Invoke();
        }
        //Do some more
        return isPerformed;
    }
