    using System;
    using System.Reflection;
    
    public class TestEvent{}
    
    public interface IDomainEventSubscriber<T>
    {
        void HandleEvent(T domainEvent);
    }
    
    class TestEventHandler : IDomainEventSubscriber<TestEvent>
    {
        public void HandleEvent(TestEvent domainEvent)
        {
            Console.WriteLine("Done");
        }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            Dispatch<TestEvent>(new TestEvent(), typeof(TestEventHandler));
        }
        
        static void Dispatch<T>(T eventToPublish, Type handlerType)
        {
            object handlerInstance = Activator.CreateInstance(handlerType);
            Type typeInfo = typeof(IDomainEventSubscriber<T>);
            MethodInfo methodInfo = typeInfo.GetMethod("HandleEvent");       
            methodInfo.Invoke(handlerInstance, new object[] { eventToPublish });
        }
    }
