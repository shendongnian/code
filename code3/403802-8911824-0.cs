    <roleManager enabled="true">
        <providers>
            <clear />
            <add connectionStringName="myConnString" applicationName="/" name="AspNetSqlRoleProvider" type="System.Web.Security.SqlRoleProvider" />
            <add applicationName="/" name="AspNetWindowsTokenRoleProvider" type="System.Web.Security.WindowsTokenRoleProvider" />
        </providers>
    </roleManager>
