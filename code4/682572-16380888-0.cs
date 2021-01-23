    public class Something {
        public class EventsHolder<T> 
        {
           static event Action<T> CollideEvent;
        }
        
        void AddEvent<T>(Action<T> collisionEvent) 
        {
          EventsHolder<T>.CollideEvent = collisionEvent;
        }
        void RaiseCollision<T>(T Obj)
        {
          var Event = EventsHolder<T>.CollideEvent;
          if (Event != null) Event(Obj);
        }
    }
