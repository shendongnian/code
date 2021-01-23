    <?xml version="1.0"?>
     <configuration>
      <location>
       <system.web>
        <authorization>
         <allow users="*" />
        </authorization>
       </system.web>
       <system.webServer>
        <httpProtocol>
        <customHeaders>
          <add name="Cache-Control" value="no-cache" />
        </customHeaders>
        </httpProtocol>
        <staticContent>
         <clientCache cacheControlMode="DisableCache" />
        </staticContent>
       </system.webServer>
      </location>
     </configuration>
