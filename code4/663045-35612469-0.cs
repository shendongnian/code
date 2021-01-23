    <system.diagnostics>
            <sources>
                <source name="System.ServiceModel" switchValue="Information, ActivityTracing" propagateActivity="false">
                    <listeners>
                        <add name="traceListener" />
                    </listeners>
                </source>
                <source name="System.ServiceModel.MessageLogging">
                    <listeners>
                        <add name="traceListener" />
                    </listeners>
                </source>
            </sources>
            <sharedListeners>
                <add name="traceListener" type="System.Diagnostics.XmlWriterTraceListener" initializeData="C:\Remos\Log\WcfTraceServer.svclog" />
            </sharedListeners>
        </system.diagnostics>
