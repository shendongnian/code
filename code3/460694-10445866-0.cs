    <roleManager enabled="true" cacheRolesInCookie="true">
        <providers>
            <clear />
            <add connectionStringName="YourDbConnectionString" 
                 applicationName="MySampleAppName"
                 name="AspNetSqlRoleProvider" 
                 type="System.Web.Security.SqlRoleProvider" />
        </providers>
    </roleManager>
