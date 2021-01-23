    <configSections>
        <section name="dataConfiguration" 
                 type="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" 
                 requirePermission="false"/>
    </configSections>
    <dataConfiguration defaultDatabase="sqlCEDB"/>
        <connectionStrings>
            <add name="sqlCEDB"
                 connectionString="Data Source=|DataDirectory|\sqlCEDB.sdf;Password='somepassword'"
                 providerName="System.Data.SqlServerCe.3.5" />
        </connectionStrings>
