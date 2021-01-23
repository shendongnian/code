    <system.diagnostics>
    <sources>
      <source propagateActivity="true" name="System.ServiceModel" switchValue="Information, ActivityTracing">
        <listeners>
          <add type="System.Diagnostics.DefaultTraceListener" name="Default">
            <filter type="" />
          </add>
          <add initializeData="C:/temp/tracelog.svclog" type="System.Diagnostics.XmlWriterTraceListener" name="traceListener">
            <filter type="" />
          </add>
        </listeners>
      </source>
    </sources>
    </system.diagnostics>
