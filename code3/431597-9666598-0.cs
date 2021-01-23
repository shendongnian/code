    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <system.diagnostics>
        <sources>
          <source name="System.Net" tracemode="protocolonly" maxdatasize="1024">
            <listeners>
              <add name="System.Net"/>
            </listeners>
          </source>
        </sources>
        <switches>
          <add name="System.Net" value="Information"/>
        </switches>
        <sharedListeners>
          <add name="System.Net"
            type="System.Diagnostics.TextWriterTraceListener"
            initializeData="network.log"
          />
        </sharedListeners>
        <trace autoflush="true"/>
      </system.diagnostics>
    </configuration>
