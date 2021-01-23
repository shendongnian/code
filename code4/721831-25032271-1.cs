    <system.diagnostics>
        <sources>
            <source name="System.ServiceModel" switchValue="Error, Critical" propagateActivity="true">
                <listeners>
                    <add name="traceListener" type="System.Diagnostics.XmlWriterTraceListener" initializeData="c:\traces.svclog" />
                </listeners>
            </source>
        </sources>
    </system.diagnostics>
