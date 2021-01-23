     <system.serviceModel>
        <services>
          <service behaviorConfiguration="CustomBehavior" name="CustomWebService">
            <endpoint address="" behaviorConfiguration="" binding="basicHttpBinding" bindingConfiguration="basicHttpBinding_Service" contract="WebService"/>
          </service>
        </services>
        <bindings>
          <basicHttpBinding>
            <binding name="basicHttpBinding_Service" maxReceivedMessageSize="4194304" receiveTimeout="00:30:00">
              <security mode="TransportCredentialOnly">
                <transport clientCredentialType="Windows"/>
                <message clientCredentialType="UserName"/>
              </security>
            </binding>
          </basicHttpBinding>
        </bindings>
        <behaviors>
          <serviceBehaviors>
            <behavior name="CustomBehavior">
              <dataContractSerializer maxItemsInObjectGraph="4194304" ignoreExtensionDataObject="True"/>
              <serviceMetadata httpGetEnabled="True"/>
              <serviceDebug httpHelpPageEnabled="true" includeExceptionDetailInFaults="true"/>
              <serviceAuthorization impersonateCallerForAllOperations="true"/>
            </behavior>
          </serviceBehaviors>
        </behaviors>
      </system.serviceModel>
