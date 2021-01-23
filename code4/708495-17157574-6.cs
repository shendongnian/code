    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
      </configSections>
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <namespace name="UnityCallHandlerConfig" />
        <assembly name="UnityCallHandlerConfig"  />
        <sectionExtension type="Microsoft.Practices.Unity.InterceptionExtension.Configuration.InterceptionConfigurationExtension, Microsoft.Practices.Unity.Interception.Configuration"/>
        <container>
          <extension type="Interception"/>
          <interception>
            <policy name="Policy">
              <matchingRule name="Match" type="Microsoft.Practices.Unity.InterceptionExtension.CustomAttributeMatchingRule, Microsoft.Practices.Unity.Interception">
                <constructor>
                  <param name="attributeType" value="UnityCallHandlerConfig.MyInterceptionAttribute, UnityCallHandlerConfig" typeConverter="AssemblyQualifiedTypeNameConverter" />
                  <param name="inherited">
                    <value value="false"/>
                  </param>
                </constructor>
              </matchingRule>
              <callHandler name="MyLogging" type="MyLoggingCallHandler">
                <lifetime type="singleton"/>
              </callHandler>
            </policy>
          </interception>
          <register type="IMyClass" mapTo="MyClass">
            <interceptor type="InterfaceInterceptor"/>
            <interceptionBehavior type="PolicyInjectionBehavior"/>
          </register>
        </container>
      </unity>
    
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5"/>
      </startup>
    </configuration>
