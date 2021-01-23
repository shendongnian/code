    public class EventProcessorFactory : IEventProcessorFactory
    {
        private readonly Dictionary<Type, IEventProcessor> _eventProcessors;
        public EventProcessorFactory(IEnumerable<EventProcessorMapping> eventProcessorMappings)
        {
            _eventProcessors = new Dictionary<Type, IEventProcessor>();
            foreach (var mapping in eventProcessorMappings)
            {
                AddMapping(Type.GetType(mapping.Event), Type.GetType(mapping.Processor));
            }
        }
        public IEventProcessor GetProcessor<T>() where T : IEventType
        {
            return _eventProcessors[typeof(T)];
        }
        private void AddMapping(Type eventType, Type processorType)
        {
            var processor = (IEventProcessor)Activator.CreateInstance(processorType);
            _eventProcessors[eventType] = processor;
        }
    }
