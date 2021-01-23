    
    <system.serviceModel>
          <bindings>
            <basicHttpBinding>
              <binding name="Demo_BasicHttp">
                <security mode="TransportCredentialOnly">
                  <transport clientCredentialType="InheritedFromHost"/>
                </security>
              </binding>
            </basicHttpBinding>
          </bindings>
          <services>
            <service name="DemoServices.CalculatorService.ServiceImplementation.CalculatorService" behaviorConfiguration="Demo_ServiceBehavior">
              <endpoint address="" binding="basicHttpBinding"
                  bindingConfiguration="Demo_BasicHttp" contract="DemoServices.CalculatorService.ServiceContracts.ICalculatorServiceContract">
                <identity>
                  <dns value="localhost"/>
                </identity>
              </endpoint>
              <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
            </service>
          </services>
          <behaviors>
            <serviceBehaviors>
              <behavior name="Demo_ServiceBehavior">
                <!-- To avoid disclosing metadata information, set the values below to false before deployment -->
                <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true"/>
                <!-- To receive exception details in faults for debugging purposes, set the value below to true.  Set to false before deployment to avoid disclosing exception information -->
                <serviceDebug includeExceptionDetailInFaults="false"/>
              </behavior>
            </serviceBehaviors>
          </behaviors>
          <protocolMapping>
            <add scheme="http" binding="basicHttpBinding" bindingConfiguration="Demo_BasicHttp"/>
          </protocolMapping>
          <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" />
        </system.serviceModel>
