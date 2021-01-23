        <system.web.webPages.razor>
          <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
          <pages pageBaseType="System.Web.Mvc.WebViewPage">
          <namespaces>
            <add namespace="System.Web.Mvc" />
            <add namespace="System.Web.Mvc.Ajax" />
            <add namespace="System.Web.Mvc.Html" />
            <add namespace="System.Web.Routing" /> 
            <add namespace="YourApplication.Utils"/>  <!-- THIS IS THE EXAMPLE ON HOW TO INSERT THE NAMESPACE THAT CONTAINS YOUR STATIC CLASS --> 
            <add namespace="Microsoft.Web.Helpers"/>
          </namespaces>
          </pages>
        </system.web.webPages.razor>
