      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <contexts>
          <context type="Company.Product.Infrastructure.BoundedContext, Company.Product.Infrastructure" disableDatabaseInitialization="false" xdt:Transform="Replace">
            <databaseInitializer type="Company.Product.Infrastructure.DatabaseInitializers.DebugDatabaseInitializer, Company.Product.Infrastructure" />
          </context>
        </contexts>
      </entityFramework>
