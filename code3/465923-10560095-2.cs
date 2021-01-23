    /// It will store observers and will push the message
    public interface IErrorObservable
    {
      void Attach(IErrorObserver observer);
      void Detach(IErrorObserver observer);
      void Notify();
    }
    public interface IErrorObserver
    {
      void Update(string message);
    }
    ///It is concrete class to push message
    public sealed class ApplicationErrorState : IErrorObservable
    {
      private List<IErrorObserver> _observers = new List<IErrorObserver>();
     
      ///constructor
      public ApplicationErrorState()
      {
      }
      public void Attach(IErrorObserver observer)
      {
         _observers.Add(observer);
      }
      public void Detach(IErrorObserver observer)
      {
         _observers.Remove(observer);
      }
      public void Notify()
      {
         foreach (IErrorObserver observer in _observers)
         {
            observer.Update(/*Logic*/);
         }
      }
      public void SetError()
      {
         Notify();
      }
      ///COncrete subject 
      private class ErrorMessageSync : IErrorObserver
      {
         private MyClass _parent;
         
         public ErrorMessageSync(MyClass parent)
         {
            _parent = parent;
         }
         public void Update(string message)
         {
                //This work will be done
         }
      }
