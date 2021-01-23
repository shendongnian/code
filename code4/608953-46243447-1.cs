    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration" />
      </configSections>
      <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
        <assembly name="ConsoleApplication1" />
        <container>
          <register type="ConsoleApplication1.IRepository[[ConsoleApplication1.One]]" mapTo="ConsoleApplication1.OneRepository" />
          <register type="ConsoleApplication1.IRepository[[ConsoleApplication1.Two]]" mapTo="ConsoleApplication1.TwoRepository" />
        </container>
      </unity>
    </configuration>
