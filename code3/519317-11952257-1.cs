    <system.webServer>
        <modules>
             <!-- UrlRewriter code here -->
             <remove name="Session" />
             <add name="Session" type="System.Web.SessionState.SessionStateModule" preCondition="" />
        </modules>
    </system.webServer>
