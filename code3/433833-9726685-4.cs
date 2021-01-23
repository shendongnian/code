    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <startup useLegacyV2RuntimeActivationPolicy="true">
        <supportedRuntime version="v4.0.30319" sku=".NETFramework,Version=v4.0,Profile=Client" />
      </startup>
      <system.data>
         <DbProviderFactories>
            <remove invariant="System.Data.SQLite"/>
            <add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".Net Framework Data Provider for SQLite"
       type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite" />
          </DbProviderFactories>
        </system.data>
    </configuration>
