    abstract class BaseMessagePump
    {
        protected abstract void SendMessage(Message m);
        public void AddListener<T>(Func<T, bool> l) where T : Message
        {
            //check a dictionary / cache
            new GenericMessageQueue<T>().listeners.Add(l);
        }
    }
    class GenericMessageQueue<T> : BaseMessagePump where T : Message
    {
        public List<Func<T, bool>> listeners;
        protected override void SendMessage(Message m) 
        {
            listeners[0]((T)m);//the cast here is safe if you do correct cache / type checking in the base add listener
        }
    }
