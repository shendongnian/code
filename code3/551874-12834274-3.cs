    <system.serviceModel>
      <behaviors>
        <serviceBehaviors>
          <behavior name="">
            <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true" />
            <serviceDebug includeExceptionDetailInFaults="false" />
          </behavior>
        </serviceBehaviors>
        <endpointBehaviors>
          <behavior name="rest">
            <webHttp/>
          </behavior>
        </endpointBehaviors>
      </behaviors>
      <services>
        <service name="WebApplication1.Service1">
          <endpoint
            address=""
            contract="WebApplication1.IService1"
            binding="webHttpBinding"
            behaviorConfiguration="rest"
            />
        </service>
      </services>
      <serviceHostingEnvironment aspNetCompatibilityEnabled="true"
          multipleSiteBindingsEnabled="true" />
    </system.serviceModel>
