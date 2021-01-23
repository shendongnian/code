      <system.web>
        <compilation debug="true">
          <assemblies>
            <!-- A bunch of other assemblies here-->
            <add assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
            <add assembly="System.Web.Extensions.Design, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
          </assemblies>
        </compilation>
        <httpModules>
          <add name="ScriptModule" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
        </httpModules>
      </system.web>
