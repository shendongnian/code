    using Xunit.Abstractions;
    using Xunit.Sdk;
    [assembly: Xunit.TestFramework("MyNamespace.MyClassName", "MyAssemblyName")]
    namespace MyNamespace
    {   
       public class MyClassName : XunitTestFramework
       {
          public MyClassName(IMessageSink messageSink)
            :base(messageSink)
          {
            // Place initialization code here
          }
       }
    }
