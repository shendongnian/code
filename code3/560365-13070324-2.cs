    class Program
    {
        static ServiceHost _service = null;
        static void Main(string[] args)
        {
            _service = new ServiceHost(typeof(TestService));
            _service.Open();
            System.Console.WriteLine("TestService Started...");
            System.Console.WriteLine("Press ENTER to close service.");
            System.Console.ReadLine();
            _service.Close();
        }
    }
    <configuration>
    <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
      </startup>
      <system.serviceModel>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true"/>
        <services>
          <service name="ConsoleApplication1.TestService">
            <host>
              <baseAddresses>
                <add baseAddress="http://localhost:6666/TestService"/>
              </baseAddresses>
            </host>
            <endpoint binding="webHttpBinding" contract="ConsoleApplication1.ITestService"
              behaviorConfiguration="webHttp"/>
          </service>      
        </services>
        <bindings>
          <webHttpBinding>
            <binding name="webHttpBinding" maxReceivedMessageSize="2147483647" maxBufferSize="2147483647">
              <readerQuotas maxArrayLength="2147483647" maxStringContentLength="2147483647"/>
            </binding>
          </webHttpBinding>
        </bindings>
        <behaviors>
          <serviceBehaviors>
            <behavior>          
              <serviceDebug includeExceptionDetailInFaults="false"/>
            </behavior>
          </serviceBehaviors>
          <endpointBehaviors>
            <behavior name="webHttp">
              <webHttp/>
            </behavior>
          </endpointBehaviors>
        </behaviors>
      </system.serviceModel>
    </configuration>
    
