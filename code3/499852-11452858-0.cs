        <system.webServer>
            <modules runAllManagedModulesForAllRequests="true">
                <remove name="UrlRoutingModule"/>
                <add name="UrlRoutingModule" type="System.Web.Routing.UrlRoutingModule, system.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
            </modules>
            <handlers>
                <add name="UrlRoutingHandler" preCondition="integratedMode" verb="*" path="UrlRouting.axd" type="System.Web.HttpForbiddenHandler, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"/>
            </handlers>
        </system.webServer>
