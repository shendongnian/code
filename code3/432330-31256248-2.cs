    <system.serviceModel>
      <!-- ****************** -->
      <behaviors>
        <serviceBehaviors>
          <behavior>
            <errorHandler />
          </behavior>
        </serviceBehaviors>
      </behaviors>
      <!-- ****************** -->
      <extensions>
        <behaviorExtensions>
          <add name ="errorHandler" type="ACME.MyErrorHandlerElement, ACME.MyErrorHandler"/>
        </behaviorExtensions>
      </extensions>
      <serviceHostingEnvironment aspNetCompatibilityEnabled="true" />
      <standardEndpoints>
        <webHttpEndpoint>
          <standardEndpoint name="" faultExceptionEnabled="false" helpEnabled="false"     automaticFormatSelectionEnabled="true"  />
        </webHttpEndpoint>
      </standardEndpoints>
    </system.serviceModel>  
