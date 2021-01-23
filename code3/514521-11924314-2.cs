    EventSystem.HookEvent<KeyEvent>(EventType.Action, Enter);
    // [...]
    public void Enter(KeyEvent keyEvent)
    {
        if (keyEvent.pressed == false)
        {
            Error.Break();
        }
    }
