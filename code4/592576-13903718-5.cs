    <system.serviceModel>
      <behaviors>
        <serviceBehaviors>
          <behavior name="InputServiceBehavior">
            <serviceMetadata httpGetEnabled="true"/>
            <serviceDebug includeExceptionDetailInFaults="false"/>
          </behavior>
        </serviceBehaviors>
      </behaviors>
      <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true"/>
      <services>
        <service behaviorConfiguration="InputServiceBehavior" name="MyNamespace.InputService">
          <endpoint address="" binding="webHttpBinding" contract="MyNamespace.InputService" bindingConfiguration="webBinding"/>
        </service>
      </services>
      <bindings>
        <webHttpBinding>
          <binding name="webBinding">
            <!--<security mode="Transport">-->
            <security mode="None"/>
          </binding>
        </webHttpBinding>
      </bindings>
    </system.serviceModel>
