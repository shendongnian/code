    foreach (EngineAction action in actionsToDo)
    {
        switch (action.Type)
        {
            case EngineActionType.Move:
                EngineActionMove mvAction = (EngineActionMove)action;
                // Example:
                player.Position = player.Position.Offset(mvAction.XDelta,
                                                         mvAction.YDelta);
                break;
            case EngineActionType.ChangePos:
                EngineActionChangePos cpAction = (EngineActionChangePos)action;
                // Example:
                player.Position = new Point(cpAction.X, cpAction.Y);
                break;
            case EngineActionType.Disappear:
                // Just make the player disappear,
                // because the operation needs no parameters
                player.Disappear();
                break;
            case ...:
            default:
                // maybe throw an error here, to find errors during development
                // it helps you find non-handled action types
        }
    }
