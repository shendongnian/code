    private void HookEvents()
    {
        foreach (EventInfo e in GetType().GetEvents())
        {
            MethodInfo method = GetType().GetMethod("HandleEvent", BindingFlags.NonPublic | BindingFlags.Instance);
            Delegate provider = Delegate.CreateDelegate(e.EventHandlerType, this, method);
            e.AddEventHandler(this, provider);
        }
    }
    private void HandleEvent(object sender, EventArgs eventArgs)
    {
        lastInteraction = DateTime.Now;
    }
