    <configuration>
      <configSections>
       <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=4.3.1.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
      </configSections>
      <connectionStrings>
        <add name="DefaultConnection" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=ESTdb-01;Integrated Security=true" providerName="System.Data.SqlClient" />
      </connectionStrings>
    
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework">
          <parameters>
            <parameter value="Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True" />
          </parameters>
        </defaultConnectionFactory>
      </entityFramework>
    </configuration>
