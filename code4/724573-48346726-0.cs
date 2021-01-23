    <configSections>
       <section name="system.identityModel" type="System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
       <section name="system.identityModel.services" type="System.IdentityModel.Services.Configuration.SystemIdentityModelServicesSection, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />
    </configSections>
    <system.webServer>
       <modules>
          <add name="SessionAuthenticationModule" 
                type="System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
       </modules>
    </system.webServer>
    <system.identityModel.services>
       <federationConfiguration>
          <cookieHandler requireSsl="false" />
       </federationConfiguration>
    </system.identityModel.services>
