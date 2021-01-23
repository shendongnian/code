    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
        <configSections>
            <section name="strings" 
                     type="Sample.StringCollectionConfigSection, SampleAssembly"/>
            <section name="databases" 
                      type="Sample.StringCollectionConfigSection, SampleAssembly"/>
        </configSections>
        <strings>
            <add>dbo.Foo</add>
            <add>dbo.Bar</add>
        </strings>
        <databases>
            <add>Development</add>
            <add>Test</add>
            <add>Staging</add>
        </databases>
    </configuration>
