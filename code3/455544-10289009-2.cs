    <system.serviceModel>
    <extensions>
      <behaviorExtensions>
        <add name="ErrorLogging" type="ErrorHandlerBehavior, ErrorHandling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=<whatever>" />
      </behaviorExtensions>
    </extensions>
    <bindings>
      <basicHttpBinding>
        <binding name="basicBinding">
        </binding>
      </basicHttpBinding>
    </bindings>
    <services>
      <service behaviorConfiguration="Service1Behavior" name="Service">
        <endpoint address="" binding="basicHttpBinding"  bindingConfiguration="basicBinding" contract="Service" />
      </service>
    </services>
    <behaviors>
      <serviceBehaviors>
        <behavior name="Service1Behavior">
          <serviceMetadata httpGetUrl="" httpGetEnabled="true" />
          <serviceDebug includeExceptionDetailInFaults="false" />
          <ErrorLogging />  <--this adds the behaviour to the service behaviours -->
        </behavior>
      </serviceBehaviors>
    </behaviors>
