    [Flags]
    public enum GameFlow
    {
        Normal = 1,
        NormalNoMove = Normal | 2,
        Paused = 4,
        Battle = 8
    }
