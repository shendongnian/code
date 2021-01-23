    public class IEvent<T> where T : EventArgs { }
    public class EventManager
    {
        public void DoMethod<T,U>() where T: IEvent<U>
        {
        }
    }
