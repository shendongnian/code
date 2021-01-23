    public static void ExecuteAction(Control myControl, Action myAction) 
    {
        if (myControl.InvokeRequired) { myControl.Invoke(myAction); }
        else { myAction(); }
    }
