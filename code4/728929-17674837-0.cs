    delegate void EventHandlerDelegate< ClassType >( ClassType p );
    class Receiver
    {
        public RegisterEvent< T >( EventHandlerDelegate< T > callback );
    }
