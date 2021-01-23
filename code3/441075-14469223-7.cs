    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="dataConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
      </configSections>
    
    
      <dataConfiguration defaultDatabase="OracleMainConnectionString">
      </dataConfiguration>
    
      <connectionStrings>
    
        <add name="OracleMainConnectionString"
             connectionString="Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=MyOracleServerName)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=MyServiceName)));User ID=MyUserName;Password=MyPassword;"
          providerName="Oracle.DataAccess.Client" />
      </connectionStrings>
    
      <appSettings>
        <add key="ExampleKey" value="ExampleValue" />
      </appSettings>
    
      <system.data>
        <DbProviderFactories>
          <clear />
          <add name="Oracle Data Provider for .NET" invariant="Oracle.DataAccess.Client" description=".Net Framework Data Provider for Oracle" type="Oracle.DataAccess.Client.OracleClientFactory, Oracle.DataAccess, Version=2.112.3.0, Culture=neutral, PublicKeyToken=89b483f429c47342" />
          <add name="EntLibContrib.Data.OdpNet" invariant="EntLibContrib.Data.OdpNet" description="EntLibContrib Data OdpNet Provider" type="EntLibContrib.Data.OdpNet.OracleDatabase, EntLibContrib.Data.OdpNet, Version=5.0.505.0, Culture=neutral, PublicKeyToken=null" />
        </DbProviderFactories>
      </system.data>
    
      
    </configuration>
