    public class Order
    {
        private readonly StateMachine<State, Trigger> _stateMachine;
        public Order()
        {
            _stateMachine = CreateStateMachine();
        }
        public bool UpdateOrderStatus(Trigger trigger)
        {
            return _stateMachine.CanFire(trigger);
        }
        private StateMachine<State, Trigger> CreateStateMachine()
        {
            StateMachine<State, Trigger> stateMachine = new StateMachine<State, Trigger>(State.New);
            stateMachine.Configure(State.New)
                .Permit(Trigger.Filled, State.Filled)
                .Permit(Trigger.Cancelled, State.Cancelled);
            stateMachine.Configure(State.Filled)
                .Permit(Trigger.ToBeShipped, State.Shipping)
                .Permit(Trigger.Cancelled, State.Cancelled);
            stateMachine.Configure(State.Shipping)
                .Permit(Trigger.Completed, State.Completed);
            stateMachine.OnUnhandledTrigger((state, trigger) =>
                {
                    Console.WriteLine("Unhandled: '{0}' state, '{1}' trigger!");
                });
            return stateMachine;
        }
    }
