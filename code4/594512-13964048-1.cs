    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=3.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
        <section name="dataConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data, Version=3.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
      </configSections>
      <loggingConfiguration name="Logging Application Block" tracingEnabled="true"
        defaultCategory="General" logWarningsWhenNoCategoriesMatch="true">
        <listeners>
          <add fileName="trace.log" header="----------------------------------------"
            footer="----------------------------------------" formatter="Custom Formatter"
            listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.FlatFileTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=3.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            traceOutputOptions="None" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.FlatFileTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=3.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            name="FlatFile TraceListener" />
        </listeners>
        <formatters>
          <add type="CustomFormatters.MyFormatter, CustomFormatters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            name="Custom Formatter" />
        </formatters>
        <categorySources>
          <add switchValue="All" name="General">
            <listeners>
              <add name="FlatFile TraceListener" />
            </listeners>
          </add>
        </categorySources>
        <specialSources>
          <allEvents switchValue="All" name="All Events" />
          <notProcessed switchValue="All" name="Unprocessed Category" />
          <errors switchValue="All" name="Logging Errors &amp; Warnings">
            <listeners>
              <add name="FlatFile TraceListener" />
            </listeners>
          </errors>
        </specialSources>
      </loggingConfiguration>
      <startup>
        <supportedRuntime version="v2.0.50727" />
      </startup>
    </configuration>
