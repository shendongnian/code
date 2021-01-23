    <configuration>
        <configSections>
            <sectionGroup name="userSettings" type="System.Configuration.UserSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
                <section name="..." type="System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" allowExeDefinition="MachineToLocalUser" requirePermission="false" />
        <!-- ... some sections in here ... -->
            </sectionGroup>
            <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
        <!-- ... some sections in here ... -->
            </sectionGroup>
    <!-- ... insert Missing section ... -->
            <section name="uri" type="System.Configuration.UriSection, System,
                          Version=2.0.0.0, Culture=neutral,
                          PublicKeyToken=b77a5c561934e089" />
        </configSections>
    <!-- ... insert URI settings ... -->
        <uri>
            <idn enabled="All" />
            <iriParsing enabled="true" />
        </uri>
        <userSettings>
        <!-- ... some settings in here ... -->
        </userSettings>
        <applicationSettings>
        <!-- ... some settings in here ... -->
        </applicationSettings>
    </configuration>
