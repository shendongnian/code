    protected virtual void OnContinue();
    protected virtual void OnCustomCommand(int command);
    protected virtual void OnPause();
    protected virtual bool OnPowerEvent(PowerBroadcastStatus powerStatus);
    protected virtual void OnSessionChange(SessionChangeDescription changeDescription);
    protected virtual void OnShutdown();
    protected virtual void OnStart(string[] args);
