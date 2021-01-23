    public class EngineActionMove : EngineAction
    {
        public int XDelta;
        public int YDelta;
        public EngineActionMove() : base(EngineActionType.Move)
        {
        }
    }
    public class EngineActionChangePos : EngineAction
    {
        ...
    }
    ...
