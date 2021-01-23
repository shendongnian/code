    using System;
    using System.Collections.Generic;
    
    using Machine.Specifications;
    
    namespace AssemblyContextSpecs
    {
      public static class DomainEvents
      {
        static readonly object @lock = new object();
    
        static Action<IDomainEvent> raiseEvent;
    
        public static void Raise<TEvent>(TEvent @event) where TEvent : class, IDomainEvent
        {
          raiseEvent(@event);
        }
    
        public static void RegisterEventPublisher(Action<IDomainEvent> eventPublisher)
        {
          lock (@lock)
          {
            raiseEvent = eventPublisher;
          }
        }
      }
    
      public interface IDomainEvent
      {
      }
    
      class FooEvent : IDomainEvent
      {
      }
    
      public class DomainEventsContext : IAssemblyContext
      {
        internal static IList<IDomainEvent> Events = new List<IDomainEvent>();
    
        public void OnAssemblyStart()
        {
          DomainEvents.RegisterEventPublisher(x => Events.Add(x));
        }
    
        public void OnAssemblyComplete()
        {
        }
      }
    
      public class When_a_domain_event_is_raised
      {
        Because of = () => DomainEvents.Raise(new FooEvent());
    
        It should_capture_the_event =
          () => DomainEventsContext.Events.ShouldContain(x => x.GetType() == typeof(FooEvent));
      }
    }
