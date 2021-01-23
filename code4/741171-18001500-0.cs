    public static class GameFlowExtensions
    {
        public static bool IsNormal(this GameFlow flow)
        {
            return (flow & (GameFlow.Normal | GameFlow.NormalNoMove)) > 0;
        }
    }
    // usage:
    if (Flow.IsNormal()) 
