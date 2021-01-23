    <configuration>
        <system.diagnostics>
            <sources>
                <source name="System.ServiceModel" 
                        switchValue="Information, ActivityTracing"
                        propagateActivity="true">
                    <listeners>
                        <add name="xml" />
                    </listeners>
                </source>
                <source name="CardSpace">
                    <listeners>
                        <add name="xml" />
                    </listeners>
                </source>
                <source name="System.IO.Log">
                    <listeners>
                        <add name="xml" />
                    </listeners>
                </source>
                <source name="System.Runtime.Serialization">
                    <listeners>
                        <add name="xml" />
                    </listeners>
                </source>
                <source name="System.IdentityModel">
                    <listeners>
                        <add name="xml" />
                    </listeners>
                </source>
            </sources>
    
            <sharedListeners>
                <add name="xml"
                     type="System.Diagnostics.XmlWriterTraceListener"
                     initializeData="c:\log\Traces.svclog" />
            </sharedListeners>
        </system.diagnostics>
    </configuration>
