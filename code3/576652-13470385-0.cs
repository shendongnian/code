    <?xml version="1.0"?>
    <configuration>
        <configSections>
            <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
                <section name="Executable.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
                <section name="DLL.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />        
            </sectionGroup>
        </configSections>
      
      <applicationSettings>
          <Executable.Properties.Settings>
              <setting name="Test" serializeAs="String">
                  <value>Testvalue EXE</value>
              </setting>
          </Executable.Properties.Settings>
          <DLL.Properties.Settings>
              <setting name="Test" serializeAs="String">
                  <value>Testvalue DLL</value>
              </setting>
          </DLL.Properties.Settings>
        </applicationSettings>
    </configuration>
