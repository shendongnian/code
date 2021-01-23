    <system.serviceModel>
                <behaviors>
                  <endpointBehaviors>
                    <behavior name="MyNamespace.MyClass.ExchangeBehavior">
                      <webHttp/>
                    </behavior>
                  </endpointBehaviors>
                </behaviors>
                <services>
                  <service name="MyNamespace.MyClass.Exchange">
                    <endpoint address="" binding="webHttpBinding" behaviorConfiguration="MyNamespace.MyClass.ExchangeBehavior" contract="MyNamespace.MyClass.IExchange" />
                  </service>
                </services>
           </system.serviceModel>
