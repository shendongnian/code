    <system.serviceModel>
        <services>
          <service name ="MyCustomExtensionService.Service1">
            <endpoint address="" behaviorConfiguration="MyCustomAttributeBehavior"
              binding="basicHttpBinding" contract="MyCustomExtensionService.IService1">
            </endpoint>
          </service>
        </services>
        <extensions>
          <behaviorExtensions>
            <add name="Validator" type="MyCustomExtensionService.MyBehaviorSection, MyCustomExtensionService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
          </behaviorExtensions>
        </extensions>
        <behaviors>
          <endpointBehaviors>
            <behavior name="MyCustomAttributeBehavior">
              <Validator />
            </behavior>
          </endpointBehaviors>
