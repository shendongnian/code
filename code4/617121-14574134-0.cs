    <system.diagnostics>
      <sources>
        <source name="System.ServiceModel"
                switchValue="Information, ActivityTracing"
                propagateActivity="true" >
          <listeners>
            <add name="xml"/>
          </listeners>
        </source>
        <source name="System.ServiceModel.MessageLogging">
          <listeners>
            <add name="xml"/>
          </listeners>
        </source>
        <source name="myUserTraceSource"
                switchValue="Information, ActivityTracing">
          <listeners>
            <add name="xml"/>
          </listeners>
        </source>
      </sources>
      <sharedListeners>
        <add name="xml"
             type="System.Diagnostics.XmlWriterTraceListener"
             initializeData="C:\logs\Error.svclog" />
      </sharedListeners>
    </system.diagnostics>
