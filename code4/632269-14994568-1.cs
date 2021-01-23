    <system.serviceModel>
        <services>
          <service name="ConsoleApplication1.Service">
            <endpoint address="" binding="wsHttpBinding" contract="ConsoleApplication1.IService" />
            <endpoint address="" binding="netTcpBinding" contract="ConsoleApplication1.IService" />
            <host>
              <baseAddresses>
                <add baseAddress="http://<machinename>:5640/SService.svc" />
                <add baseAddress="net.tcp://<machinename>:5641/SService.svc" />
              </baseAddresses>
            </host>
          </service>
        </services>
        <behaviors>
          <serviceBehaviors>
            <behavior>
              <serviceMetadata httpGetEnabled="true"/>
              <serviceDebug includeExceptionDetailInFaults="False"/>
            </behavior>
          </serviceBehaviors>
        </behaviors>
      </system.serviceModel>
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ServiceHost host = new ServiceHost(typeof(Service));
                host.Open();
    
                Console.ReadLine();
            }
        }
    
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            string DoWork();
        }
    
        public class Service : IService
        {
            public string DoWork()
            {
                return "Hello world";
            }
        }
    }
