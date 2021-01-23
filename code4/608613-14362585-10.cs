    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
        <configSections>
            <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
        </configSections>
        <loggingConfiguration name="" tracingEnabled="true" defaultCategory="General"
            logWarningsWhenNoCategoriesMatch="false">
            <listeners>
                <add name="Flat File Trace Listener" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.FlatFileTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.FlatFileTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    fileName="trace.log" formatter="Text Formatter" traceOutputOptions="LogicalOperationStack" />
            </listeners>
            <formatters>
                <add type="Microsoft.Practices.EnterpriseLibrary.Logging.Formatters.TextFormatter, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    template="Timestamp: {timestamp}
