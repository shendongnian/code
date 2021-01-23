    <connectionStrings>
        <add name="hublisherEntities" connectionString="Data Source=localhost;Initial Catalog=hublisher;Integrated Security=True;" providerName="System.Data.SqlClient" />
    </connectionStrings>
    <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
            <parameters>
                <parameter value="Data Source=localhost;Initial Catalog=hublisher;Integrated Security=True" />
            </parameters>
        </defaultConnectionFactory>
    </entityFramework>
