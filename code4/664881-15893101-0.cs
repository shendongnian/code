      public abstract class ProxyBase
      {
        public void Execute()
        {
          PreCondition();
          Call();
          PostCondition();
        }
        private void PreCondition()
        {
          Console.WriteLine("ProxyBase.PreCondition()");
        }
        private void PostCondition()
        {
          Console.WriteLine("ProxyBase.PreCondition()");
        }
        protected abstract void Call();
      }
      public class AppProxy<T> : ProxyBase where T : IApp
      {
        private IApp _app;
    
        public AppProxy<T> Init(IApp app)
        {
          _app = app;
          return this;
        }
    
        protected override void Call()
        {
          Console.WriteLine("AppProxy.Call()");
          _app.Call();
        }
    
        public IApp Object
        {
          get { return _app; }
        }
      }
    
      public interface IApp
      {
        void Call();
      }
    
      public interface IFoo : IApp
      {
    
      }
    
      public class ActualFoo : IApp
      {
        public void Call()
        {
          Console.WriteLine("ActualFoo.Call()");
        }
      }
    
     class Program
      {
        static void Main(string[] args)
        {
          ActualFoo actualFoo = new ActualFoo();
          var app = new AppProxy<IFoo>().Init(actualFoo);
          app.Execute();
          var o = app.Object as ActualFoo;
    
          Console.ReadLine();
    
        }
      }
