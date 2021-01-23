    <configSections>
      <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration"/>
    </configSections>
    <unity>
      <containers>
        <container>
          <register type="System.String, MyProject">
            <constructor>
              <param name="name" value="chris" />
            </constructor>
          </register >
        </container>
      </containers>
    </unity>
