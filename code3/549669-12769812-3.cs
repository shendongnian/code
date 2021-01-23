    public abstract class EngineAction
    {
        public readonly EngineActionType Type;
        protected EngineAction(EngineActionType type)
        {
            this.Type = type;
        }
    }
