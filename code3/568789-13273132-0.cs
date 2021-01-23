    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <system.diagnostics>
        <sources>
          <source name="System.Net" switchValue="All">
            <listeners>
              <add name="nlog" />
            </listeners>
          </source>
          <source name="System.Net.Sockets" switchValue="All">
            <listeners>
              <add name="nlog" />
            </listeners>
          </source>
        </sources>
        <sharedListeners>
          <add name="nlog" type="NLog.NLogTraceListener, NLog" />
        </sharedListeners>
      </system.diagnostics>
    </configuration>
