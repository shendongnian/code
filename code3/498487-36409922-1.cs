    <system.web>
      <httpHandlers>
        <add verb=" * "  path="Reserved.ReportViewerWebControl.axd" 
             type="Microsoft.Reporting.WebForms.HttpHandler,
                   Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral,
                   PublicKeyToken=b03f5f7f11d50a3a" />
      </httpHandlers>
    </system.web>
    <system.webServer>
      <handlers>
        <add name="ReportViewerWebControlHandler" preCondition="integratedMode"
             verb="*" path="Reserved.ReportViewerWebControl.axd" 
             type="Microsoft.Reporting.WebForms.HttpHandler, 
                   Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral,
                   PublicKeyToken=b03f5f7f11d50a3a"/>
      </handlers>
    </system.webServer>
