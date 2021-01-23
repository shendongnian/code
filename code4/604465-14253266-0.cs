    public class StateTransition {
        public event Func<bool> Condition;
        protected virtual bool OnCondition() {
            var handler = Condition;
            return handler == null ? false : handler();
        }
        public event Action ActionToTake;
        protected virtual void OnActionToTake() {
            var handler = ActionToTake;
            if(handler != null) handler();
        }
        public event Func<bool> VerifyActionWorked;
        protected virtual bool OnVerifyActionWorked() {
            var handler = VerifyActionWorked;
            return handler == null ? true : handler();
        }
        // TODO: think about default return values
    }
