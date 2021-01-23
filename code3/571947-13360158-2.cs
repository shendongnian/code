    <system.serviceModel>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true"/>
        <standardEndpoints>
          <webHttpEndpoint>
            <standardEndpoint name="" helpEnabled="true" automaticFormatSelectionEnabled="false"/>
          </webHttpEndpoint>
        </standardEndpoints>
        <services>
          <service name="OmniData">
            <!-- Service Endpoints -->
            <host>
              <baseAddresses>
                <add baseAddress="http://localhost:55641"/>
              </baseAddresses>
            </host>
            <endpoint address="" binding="webHttpBinding" contract="ControlService.IOmniData" behaviorConfiguration="rest" />
          </service>
        </services>
        <behaviors>
          <endpointBehaviors>
            <behavior name="rest">
              <webHttp />
            </behavior>
          </endpointBehaviors>
          <serviceBehaviors>
            <behavior name="Default">
              <serviceMetadata httpGetEnabled="true"/>
            </behavior>
          </serviceBehaviors>
        </behaviors>
      </system.serviceModel>
