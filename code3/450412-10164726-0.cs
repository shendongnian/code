     <?xml version="1.0"?>
    <configuration>
      <configSections>
        <sectionGroup name="system.serviceModel">
          <section name="domainServices" type="System.ServiceModel.DomainServices.Hosting.DomainServicesSection, System.ServiceModel.DomainServices.Hosting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" allowDefinition="MachineToApplication" requirePermission="false" />
        </sectionGroup>
      </configSections>
      <connectionStrings>
        <add name="DefaultConnectionString" connectionString="My Connection Details"
    providerName="System.Data.SqlClient" />
    
      </connectionStrings>
    
    
      <system.web>
    
        <roleManager enabled="true" defaultProvider="DPISqlRoleProvider">
          <providers>
            <add connectionStringName="DefaultConnectionString" applicationName="DPI" name="DPISqlRoleProvider"
     type="System.Web.Security.SqlRoleProvider"/>
    
          </providers>
        </roleManager>
        <httpModules>
          <add name="DomainServiceModule" type="System.ServiceModel.DomainServices.Hosting.DomainServiceHttpModule, System.ServiceModel.DomainServices.Hosting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        </httpModules>
        <compilation debug="true" targetFramework="4.0" />
    
    
    
        <authentication mode="Forms">
    
        </authentication>
    
    
        <membership defaultProvider="DPISqlMembershipProvider">
    
          <providers>
            <add connectionStringName="DefaultConnectionString" enablePasswordRetrieval="false" enablePasswordReset="true"
     requiresQuestionAndAnswer="true" applicationName="DPI" requiresUniqueEmail="true" passwordFormat="Hashed"
     maxInvalidPasswordAttempts="5" minRequiredPasswordLength="4" minRequiredNonalphanumericCharacters="0"
     passwordAttemptWindow="10" passwordStrengthRegularExpression="" name="DPISqlMembershipProvider" type="System.Web.Security.SqlMembershipProvider"/>
    
          </providers>
        </membership>
        <profile>
          <properties>
            <add name="FriendlyName"/>
          </properties>
        </profile>
    
      </system.web>
    
      <system.webServer>
        <validation validateIntegratedModeConfiguration="false"/>
        <modules runAllManagedModulesForAllRequests="true">
          <add name="DomainServiceModule" preCondition="managedHandler"
              type="System.ServiceModel.DomainServices.Hosting.DomainServiceHttpModule, System.ServiceModel.DomainServices.Hosting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        </modules>
      </system.webServer>
    
      <system.serviceModel>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" />
      </system.serviceModel>
    </configuration>
