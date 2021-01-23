    <loggingConfiguration name="" tracingEnabled="true" defaultCategory="General">
        <listeners>
            <add name="Event Log Listener" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.FormattedEventLogTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.FormattedEventLogTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                source="Enterprise Library Logging" formatter="Text Formatter"
                log="" machineName="." traceOutputOptions="None" />
            <add name="Flat File Trace Listener" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.FlatFileTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.FlatFileTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                fileName="c:\\Log\\wclog.log" header=""
                formatter="Text Formatter" traceOutputOptions="DateTime, Timestamp" />
        </listeners>
        <formatters>
            <add type="Microsoft.Practices.EnterpriseLibrary.Logging.Formatters.TextFormatter, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                template="Timestamp:{timestamp}  Method: {title}, {category} {message}"
                name="Text Formatter" />
        </formatters>
        <categorySources>
            <add switchValue="All" name="General">
                <listeners>
                    <add name="Flat File Trace Listener" />
                </listeners>
            </add>
        </categorySources>
        <specialSources>
            <allEvents switchValue="All" name="All Events">
                <listeners>
                    <add name="Flat File Trace Listener" />
                </listeners>
            </allEvents>
            <notProcessed switchValue="All" name="Unprocessed Category">
                <listeners>
                    <add name="Flat File Trace Listener" />
                </listeners>
            </notProcessed>
            <errors switchValue="All" name="Logging Errors &amp; Warnings">
                <listeners>
                    <add name="Flat File Trace Listener" />
                </listeners>
            </errors>
        </specialSources>
