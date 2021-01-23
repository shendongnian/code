    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection,Microsoft.Practices.Unity.Configuration"/>
      </configSections>
      <unity xmlns="schemas.microsoft.com/practices/2010/unity">
        <sectionExtension type="Unity.FactoryConfig.FactoryConfigExtension, Unity.FactoryConfig"/>
        <alias alias="Factory" type="Namespace1.GenericFactory`1, asm1"/>
        <container>
          <register type="Namespace1.ITest, asm1">
            <factory type="Factory[[Namespace1.ITest, asm1]]" method="Create" />
          </register>
        </container>
      </unity>
    </configuration>
