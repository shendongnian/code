    <configuration>
      <system.diagnostics>
        <sources>
          <source name="System.Net" tracemode="includehex" maxdatasize="1024">
            <listeners>
              <add name="System.Net"/>
            </listeners>
          </source>
          <source name="System.Net.Cache">
            <listeners>
              <add name="System.Net"/>
            </listeners>
          </source>
          <source name="System.Net.Http">
            <listeners>
              <add name="System.Net "/>
            </listeners>
          </source>
          <source name="System.Net.Sockets">
            <listeners>
              <add name="System.Net"/>
            </listeners>
          </source>
          <source name="System.Net.WebSockets">
            <listeners>
              <add name="System.Net"/>
            </listeners>
          </source>
        </sources>
        <switches>
          <add name="System.Net" value="Verbose"/>
          <add name="System.Net.Cache" value="Off"/>
          <add name="System.Net.Http" value="Off"/>
          <add name="System.Net.Sockets" value="Verbose"/>
          <add name="System.Net.WebSockets" value="Off"/>
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
