      <system.serviceModel>
        <behaviors>
          <serviceBehaviors>
            <behavior name="">
              <serviceMetadata httpGetEnabled="true" />
              <serviceDebug includeExceptionDetailInFaults="false" />
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <serviceHostingEnvironment multipleSiteBindingsEnabled="true" />
        <services>
          <service name="WebApplication1.Service1">
            <endpoint address="" binding="wsHttpBinding" contract="WebApplication1.IService1" />
            <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange" />
          </service>
        </services>
      </system.serviceModel>
