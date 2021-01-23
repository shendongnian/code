    public class ValidatingStateContainer<TState, TAction> : IStateContainer<TState, TAction> {
        public ValidatingStateContainer(TState state) {
            State = state;
        }
        public TState State { get; private set; }
        public void Execute(TAction action)
        {
            if (action.IsValid(this))
                action.Apply(State);
        }
    }
    public class ActionSet5IfZero : IAction<NumberState>
    {
        public boolean IsValid(NumberState state)
        {
            if (state.Number == 0)
                return true;
            else
                return false;
        }
        public void Apply(NumberState state)
        {
            state.Number = 5;
        }
    }
    public class ExtendedActionSet5IfZero : ActionSet5IfZero, IAction<TwoNumberState>
    {   
        public boolean IsValid(TwoNumberState state)
        {
            if (base.IsValid(state) && state.Number2 == 0)
                return true;
            else
                return false;
        }
    
        public void Apply(TwoNumberState state)
        {
            base.Apply(state);
            state.Number2 = 5;
        }
    }
    public class NumberState : IState {
        public int Number { get; set; }
    }
    public class TwoNumberState : NumberState {
        public int Number2 { get; set; }
    }
