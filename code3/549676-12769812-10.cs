    public interface IEngineAction
    {
        void Do(Player target);
    }
    public class EngineActionMove : IEngineAction
    {
        public int XDelta;
        public int XDelta;
        public void Do(Player target)
        {
            // Example
            target.Position = ...
        }
    }
    public class EngineActionDisappear : IEngineAction
    {
        public void Do(Player target)
        {
            // Example
            target.Visible = false;
        }
    }
    ...
