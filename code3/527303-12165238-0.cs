    interface IEventAdapter
    {
        CustomEventArgs Transform(EventArgs E);
    }
    
    public class EventListener
    {
        Dictionary<Type, IEventAdapter> _adapters;
    
        public void Map(Type providerType, IEventAdapter adapter)
        {
            _adapters.Add(providerType, adapter);
        }
    
        public void Subscribe(IProvider provider)
        {
            //hook event
        }
    
        protected void OnEvent(object source, EventArgs e)
        {
            var theArgs = _adapters[source.GetType()].Adapt(e);
            TheEvent(source, theArgs);
        }
    
        public EventHandler<CustomEventArgs> TheEvent;
    }
