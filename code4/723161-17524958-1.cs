    public abstract class Component 
    {
      protected Component _next;
      protected MessageSpecification _specification;
      public Component(MessageSpecification specification)
      {
        // Inject specification here
      }
    
      public void Inspect(Message message)
      {
        if (_specification.IsSatisfiedBy(message))
        {
           Handle(message);
        }
        else _next.Inspect(message);
      }
      abstract void Handle(Message message);
    }
