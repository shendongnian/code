    abstract class AbstractAction
    {
        public abstract ActionType actionType { get; }
    }
    class ActionMove : AbstractAction
    {
        public override ActionType actionType
        {
            get { return ActionType.Move; }
        }
    }
