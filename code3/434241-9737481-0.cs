    <system.diagnostics>
      <sources>
        <source name="System.ServiceModel" switchValue="Warning, ActivityTracing" propagateActivity="true">
          <listeners>
            <add type="System.Diagnostics.DefaultTraceListener" name="Default">
              <filter type="" />
            </add>
            <add name="ServiceModelTraceListener">
              <filter type="" />
            </add>
          </listeners>
        </source>
      </sources>
      <sharedListeners>
        <add initializeData="path\to\trace.svclog"
          type="System.Diagnostics.XmlWriterTraceListener, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        name="ServiceModelTraceListener" traceOutputOptions="Timestamp">
        <filter type="" />
      </add>
    </sharedListeners>
