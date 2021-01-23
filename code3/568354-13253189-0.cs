      internal class Program
      {
        private static void Main(string[] args)
        {
    
          var interceptor = new Interceptor();
          var businessObjectClass = new ProxyGenerator().CreateInterfaceProxyWithoutTarget<IBusinessObjectClass>(interceptor);
    
          businessObjectClass.Method3("what",123);
    
          Console.ReadLine();
        }
      }
    
      public class Interceptor : IInterceptor
      {
        #region IInterceptor Members
    
        public void Intercept(IInvocation invocation)
        {
          Console.WriteLine(string.Format("Intercepted call to: " + invocation.Method.Name));
          foreach (var argument in invocation.Arguments)
          {
            Console.WriteLine(string.Format("\t Param: " + argument.ToString()));
          }
          invocation.Proceed();
        }
    
        #endregion
      }
    
      public interface IBusinessObjectClass
      {
        void Method3(string stringValue, int intValue);
      }
    
      public class BusinessObjectClass : IBusinessObjectClass
      {
    
         public void Method3(string stringValue, int intValue)
        {
          return;
         }
    
      }
