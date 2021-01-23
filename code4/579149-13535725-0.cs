    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration" />
      </configSections>
      <unity>
        <containers>
          <container>
            <types>
              <type name="OutputService1" type="InterfacesLibrary.IOutputService, InterfacesLibrary" mapTo="InputOutputLibrary.ConsoleOutputService, InputOutputLibrary" />
              <type name="OutputService2" type="InterfacesLibrary.IOutputService, InterfacesLibrary" mapTo="InputOutputLibrary.MsgBoxOutputService, InputOutputLibrary" />
            </types>
          </container>
       </containers>
      </unity>
    </configuration>
