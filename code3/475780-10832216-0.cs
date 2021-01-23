    interface IInputSource<T> where T : EventArgs
    {
        event EventHandler<T> InputEvent;
    }
    interface IInputSink<in T> where T : EventArgs
    {
        void InputMessageHandler(object sender, T eventArgs);
    }
    internal class InputManager
    {
        private Dictionary<Type, object> _inputSources;
        private Dictionary<Type, object> _inputSinks;
        private Dictionary<Type, object> _events;
        public void AddSource<T>(IInputSource<T> source) where T : EventArgs
        {
            _inputSources[typeof(T)] = _inputSources;      //add source
            _events[typeof(T)] = (EventHandler<T>)Dispatch; //register event for subscribers
            source.InputEvent += Dispatch;
            source.InputEvent += Dispatch2;
        }
        // Dispatch trough direct event subscriptions;
        private void Dispatch<T>(object sender, T e) where T : EventArgs
        {
            var handler = _events[typeof(T)] as EventHandler<T>;
            handler.Invoke(sender, e);
        }
        // Dispatch trough IInputSink subscriptions;
        private void Dispatch2<T>(object sender, T e) where T : EventArgs
        {
            var sink = _inputSinks[typeof(T)] as IInputSink<T>;
            sink.InputMessageHandler(sender, e);
        }
        //Subscription:  Client should provide handler into Subscribe()
        //or subscribe with IInputSink<MyEvent> implementation (Subscribe2())
        public void Subscribe<T>(EventHandler<T> handler) where T : EventArgs
        {
            var @event = _events[typeof(T)] as EventHandler<T>;
            _events[typeof(T)] = @event + handler;
        }
        public void Subscribe2<T>(IInputSink<T> sink) where T : EventArgs
        {
            _inputSinks[typeof(T)] = sink;
        }
    }
    class XXXX : EventArgs
    {
    }
    public class Sink: IInputSink<XXXX>
    {
        #region Implementation of IInputSink<in XXXX>
        public void InputMessageHandler(object sender, XXXX eventArgs)
        {
            throw new NotImplementedException();
        }
        #endregion
        public Sink() 
        {
            var v = new InputManager();
            v.Subscribe<XXXX>(GetInputEvent);
            v.Subscribe2(this);
        }
        private void GetInputEvent(object sender, XXXX xxxx)
        {
            throw new NotImplementedException();
        }
    }
