    <system.serviceModel>
    <behaviors>
      <serviceBehaviors>
        <behavior name="">
          <serviceMetadata httpGetEnabled="true" />
          <serviceDebug includeExceptionDetailInFaults="false" />
        </behavior>
      </serviceBehaviors>
    </behaviors>
    <bindings>
      <customBinding>
        <binding name="customBinding0">
          <binaryMessageEncoding />
          <httpTransport />
        </binding>
      </customBinding>
    </bindings>
    <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" />
    <standardEndpoints>
      <webHttpEndpoint>
        <standardEndpoint name="" helpEnabled="true" defaultOutgoingResponseFormat="Json" automaticFormatSelectionEnabled="true" maxReceivedMessageSize="1048576">
          <readerQuotas maxStringContentLength="1048576" />
        </standardEndpoint>
      </webHttpEndpoint>
    </standardEndpoints>
    </system.serviceModel>
