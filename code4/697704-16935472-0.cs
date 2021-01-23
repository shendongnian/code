    <configuration>
      <system.web>
        <compilation debug="true" targetFramework="4.0" />
      </system.web>
      <system.serviceModel>
        <services>
          <service name="TestTheIso.Service1" behaviorConfiguration="ServiceBehaviour">
            <endpoint  binding="customBinding" bindingConfiguration="DefaultBinding"   contract="TestTheIso.IService1" behaviorConfiguration="toto">
            </endpoint>
          </service>
        </services>
        <bindings>
          <customBinding>
            <binding name="DefaultBinding">
              <customTextMessageEncoding encoding="ISO-8859-1" messageVersion="None" />
              <httpTransport manualAddressing="true"/>
            </binding>
          </customBinding>
        </bindings>
        <behaviors>
          <serviceBehaviors>
            <behavior name="ServiceBehaviour">
              <serviceMetadata httpGetEnabled="true"/>
              <serviceDebug includeExceptionDetailInFaults="false"/>
            </behavior>
            <behavior>
              <serviceMetadata httpGetEnabled="true"/>
              <serviceDebug includeExceptionDetailInFaults="false"/>
            </behavior>
          </serviceBehaviors>
          <endpointBehaviors>
            <behavior name="toto">
              <webHttp helpEnabled="true" automaticFormatSelectionEnabled="false" defaultOutgoingResponseFormat="Json" />
            </behavior>
          </endpointBehaviors>
        </behaviors>
        <serviceHostingEnvironment multipleSiteBindingsEnabled="true" />
        <extensions>
          <bindingElementExtensions>
            <add name="customTextMessageEncoding"
                 type="Microsoft.Samples.CustomTextMessageEncoder.CustomTextMessageEncodingElement, CustomTextMessageEncoder"/>
          </bindingElementExtensions>
        </extensions>
      </system.serviceModel>
      <system.webServer>
        <modules runAllManagedModulesForAllRequests="true"/>
      </system.webServer>
    </configuration>
