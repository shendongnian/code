    public abstract class PresentationEvent<TPresentationEventArgs> where TPresentationEventArgs : IPresentationEventArgs
    {
        private Action<TPresentationEventArgs> _actions = args => { };
        public void Subscribe(Action<TPresentationEventArgs> action)
        {
            _actions += action;
        }
        public void Publish(TPresentationEventArgs message)
        {
            _actions(message);
        }
    }
