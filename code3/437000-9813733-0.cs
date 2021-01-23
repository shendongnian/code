    <system.webServer>
      <validation validateIntegratedModeConfiguration="false"/>
        <modules>
           <add name="Spring" type="Spring.Context.Support.WebSupportModule, Spring.Web"/>
        </modules>
        <handlers>
          <add name="SpringPageHandler" verb="*" path="*.aspx" type="Spring.Web.Support.PageHandlerFactory, Spring.Web"/>
          <add name="SpringWebServiceHandler" verb="*" path="*.asmx" type="Spring.Web.Services.WebServiceHandlerFactory, Spring.Web" />
          <add name="SpringContextMonitor" verb="*" path="ContextMonitor.ashx" type="Spring.Web.Support.ContextMonitor, Spring.Web"/>
        </handlers>
    </system.webServer>
