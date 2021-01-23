    public abstract class EngineAction
    {
        public readonly EngineActionType Type;
        protected EngineAction(EngineActionType type)
        {
            this.Type = type;
        }
    }
    public class EngineActionMove : EngineAction
    {
        public int XDelta;
        public int YDelta;
        public EngineActionMove() : base(EngineActionType.Move)
        {
        }
    }
