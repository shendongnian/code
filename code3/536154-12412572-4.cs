    <system.diagnostics>
      <sources>
        <source name="TraceTest" switchName="SourceSwitch"
                switchType="System.Diagnostics.SourceSwitch">
          <listeners>
                <!-- choose one or use multiple TraceListeners -->
                <add name="console" type="System.Diagnostics.ConsoleTraceListener"
                     initializeData="false"/>
                <add name="file" type="System.Diagnostics.TextWriterTraceListener"
                     initializeData="error.log"/>
                <remove name ="Default"/>
          </listeners>
        </source>
       </sources>
       <switches>
        <!--  MSDN: 4 verbose Information, Information 3, Warning 2, Error 1, -->
        <add name="SourceSwitch" value="Error"/>
      </switches>
      <trace autoflush="true" indentsize="4"/>
    </system.diagnostics>
