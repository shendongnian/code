    <configuration>
        <system.diagnostics>
            <switches>
                <!--  0-off, 1-error, 2-warn, 3-info, 4-verbose. -->
                <add name="TraceLevelSwitch" value="0" />
            </switches>
            <trace autoflush="true" indentsize="4">
                <listeners>
                    <add name="myListener" type="MorPilasTraceListener" />
                </listeners>
            </trace>
        </system.diagnostics>
    </configuration>
---
    private static TraceSwitch traceSwitch = new TraceSwitch("TraceLevelSwitch", null);
    private static void LogInfo(string message)
    {
        if(traceSwitch.TraceInfo)
            Trace.TraceInformation(message);
    }
