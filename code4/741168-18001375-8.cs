    [Flags]
    public enum GameFlow
    {
        Normal = 1,
        NormalNoMove = 2,
        Paused = 4,
        Battle = 8,
        AnyNormal = Normal | NormalNoMove
    }
    
    bool IsNormal(GameFlow flow)
    {
        return (flow & GameFlow.AnyNormal) > 0;
    }
