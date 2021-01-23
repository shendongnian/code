    <configSections>
        <section name="unity"
               type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection,
                     Microsoft.Practices.Unity.Configuration, Version=3.0.0.0,
                     Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
    
      </configSections>
    <unity>
    
      <typeAliases>
    
        <!-- Lifetime manager types -->
        <typeAlias alias="singleton" type="Microsoft.Practices.Unity.ContainerControlledLifetimeManager, Microsoft.Practices.Unity" />
        <typeAlias alias="external"  type="Microsoft.Practices.Unity.ExternallyControlledLifetimeManager, Microsoft.Practices.Unity" />
    
        <!-- Custom object types -->
        <typeAlias alias="IMasterInterface"           type="UnityInjection.IMasterInterface, UnityInjection" />
        <typeAlias alias="MasterImp"                  type="UnityInjection.MasterImplementation, UnityInjection" />
        <typeAlias alias="SatelliteOneImplementation" type="Satellite1.Implementation1, Satellite1" />
        <typeAlias alias="SatelliteTwoImplementation" type="Satellite2.Implementation2, Satellite2" />
      </typeAliases>
    
      <containers>
    
        <container name="containerOne">
    
          <types>
    
            <type type="IMasterInterface" mapTo="MasterImp" name="Master" />
    
            <type type="IMasterInterface" mapTo="SatelliteOneImplementation" name="One" />
    
            <type type="IMasterInterface" mapTo="SatelliteTwoImplementation" name="Two" />
          
          </types>
        </container>
      </containers>
    </unity>
