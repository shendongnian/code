    <profile defaultProvider="AspNetSqlProfileProvider">
      <providers>
        <clear/>
        <add name="AspNetSqlProfileProvider" type="System.Web.Profile.SqlProfileProvider" connectionStringName="ErpConnectionString" applicationName="/ERP"/>
      </providers>
      <properties>
        <add name="Startpage"/>
      </properties>
    </profile>
