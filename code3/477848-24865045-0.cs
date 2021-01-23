    Try use:
    
    <system.diagnostics>
        <sources>
          <source name="LoggerApp" switchName="sourceSwitch" switchType="System.Diagnostics.SourceSwitch">
            <listeners>
              <add name="myListener" type="System.Diagnostics.TextWriterTraceListener" initializeData="myListener-{0:dd}-{0:MM}-{0:yyyy}.log" />
            </listeners>
          </source>
        </sources>
        <switches>
          <add name="sourceSwitch" value="Information" />
        </switches>
      </system.diagnostics>
