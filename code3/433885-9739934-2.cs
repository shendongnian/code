    internal sealed class Configuration : DbMigrationsConfiguration<YourDbContext>
    {
        public Configuration()
        {
            // Because the Package Manager Console (NuGet) instantiates YourDbContext with the empty constructor,
            // a custom connection must be specified. Based on http://www.devart.com/blogs/dotconnect/?p=5603
            // Note that the MySqlProviderFactory must also be present in Web.config or App.config in the *startup project*
            // for this to work! Configuration example:
    
            /*
              <system.data>
                <DbProviderFactories>
                  <clear />
                  <remove invariant="Devart.Data.MySql" />
                  <add name="dotConnect for MySQL" invariant="Devart.Data.MySql" description="Devart dotConnect for MySQL" type="Devart.Data.MySql.MySqlProviderFactory, Devart.Data.MySql, Version=6.30.196.0, Culture=neutral, PublicKeyToken=09af7300eec23701" />
                </DbProviderFactories>
              </system.data>
            */
    
            // Apply the IgnoreSchemaName workaround
            MySqlEntityProviderConfig.Instance.Workarounds.IgnoreSchemaName = true;
    
            // Create a custom connection to specify the database and set a SQL generator for MySql.
            var connectionInfo = MySqlConnectionInfo.CreateConnection("<Your ConnectionString>");
    
            TargetDatabase = connectionInfo;
            SetSqlGenerator(connectionInfo.GetInvariantName(), new MySqlEntityMigrationSqlGenerator());
    
            // Enable automatic migrations if you like
            AutomaticMigrationsEnabled = false;
    
            // There is some problem with referencing EntityFramework 4.3.1.0 for me, so another fix that needs
            // to be applied in Web.config is this:
    
            /*
              <runtime>
                <assemblyBinding>
                  <!-- This redirection is needed for EntityFramework Migrations through the Package Manager Console (NuGet) -->
                  <dependentAssembly>
                    <assemblyIdentity name="EntityFramework" publicKeyToken="b77a5c561934e089" />
                    <bindingRedirect oldVersion="4.3.0.0" newVersion="4.3.1.0" />
                  </dependentAssembly>
                </assemblyBinding>
              </runtime>
            */
    
            // After these Web.config additions, running migrations in Package Manager Console should be as easy as:
            // Update-Database -Verbose -ProjectName Your.MigrationsProject
    
            // Creating new migrations:
            // Add-Migration -Name MigrationDescription -ProjectName Your.MigrationsProject
        }
    }
